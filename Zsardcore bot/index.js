const {Client, GatewayIntentBits, REST, Routes, ActivityType, EmbedBuilder} = require("discord.js");
const client = new Client({intents: [GatewayIntentBits.GuildMessages, GatewayIntentBits.Guilds, GatewayIntentBits.MessageContent, GatewayIntentBits.GuildMembers]});
const config = require("./config.json");
const mysql = require("mysql")
const HU = require("./languages/HU.json")
const ENG = require("./languages/ENG.json")
const DE = require("./languages/DE.json")
const CZ = require("./languages/CZ.json")
const PL = require("./languages/PL.json")

const giveawaybot = require('./giveaway/index.js')

const languages = [HU, ENG, DE, CZ, PL]

let con = mysql.createConnection({
    host: config.sql.host,
    user: config.sql.user,
    password: config.sql.password,
    database: config.sql.database
})

con.connect(function(err) {
    if (err) throw err;
})

function pingBot()
{
    const date = new Date()
    main()
    console.log(`Ping küldve ekkor: ${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`)
    setTimeout(pingBot, 600000);
}

function pingConnection()
{
    con.ping((err) => {
        if (err) {
            console.error("Adatbázis kapcsolat megszakadt. Új kapcsolat létrehozása folyamatban...");
            con = mysql.createConnection({
                host: config.sql.host,
                user: config.sql.user,
                password: config.sql.password,
                database: config.sql.database
            })
            con.connect((err) => {
                if (err) {
                    console.error("Hiba keletkezett az újrapróbálkozás során. Hiba:", err);
                } else {
                    console.log("Adatbázis kapcsolat újra létrehozva!");
                }
            });
        }
    });
    setTimeout(pingConnection, 600000)
}

const Roles = ["1198220272575205406", "1197960653860786206", "1197960790070788236", "1197245687444811826", "1197245149122670693", "1198223342029770772", "1197960790070788236", "1202717673600065607"] 

async function removeRole() {
    try {
        con.query("SELECT UserID, needRoles FROM Adatok", async (err,rows) => {
            if (err) throw err
            const guild = client.guilds.cache.get(config.guildId);

            for (let i = 0; i < rows.length; i++) {
                const uID = rows[i].UserID;
                const needRole = rows[i].needRoles;

                try
                {
                    const member = await guild.members.fetch(uID);
                    if(member) 
                    {
                        const hasRole = Roles.some(roleID => member.roles.cache.has(roleID));

                        if (!hasRole && needRole == '1') { //Ha nincs rangja és kell rang
                            con.query(`UPDATE Adatok SET canPlay=0 WHERE UserID='${member.user.id}'`);
                        }
                    }
                } catch (err)
                {
                    
                }
            } 
        })
    } catch (err) {
        console.error(err);
    }
    setTimeout(removeRole, 604800000);
}

function addRole() {
    try {
        con.query("SELECT UserID, needRoles FROM Adatok", async (err,rows) => {
            if (err) throw err
            const guild = client.guilds.cache.get(config.guildId)

            for (let i = 0; i < rows.length; i++) {
                const uID = rows[i].UserID;
                const needRole = rows[i].needRoles;

                try
                {
                    const member = await guild.members.fetch(uID);
                    if (member) {
                        const hasRole = Roles.some(roleID => member.roles.cache.has(roleID));

                        if (hasRole && needRole == '1') { // Ha van rangja és kell rang
                            con.query(`UPDATE Adatok SET canPlay=1 WHERE UserID='${member.user.id}'`);
                        } 
                        else if (needRole == '0') { // Ha nem kell rang
                            con.query(`UPDATE Adatok SET canPlay=1 WHERE UserID='${member.user.id}'`);
                        }
                    }
                } 
                catch (err)
                {
                    con.query(`DELETE FROM Adatok WHERE UserID='${uID}'`);
                } 
            }
        })
    } catch (err) {
        console.error(err);
    }
    setTimeout(addRole, 60000);
}

let lastState;

async function updateServerStatus() {
    try {
        const rows = await new Promise((resolve, reject) => {
            con.query("SELECT isRunning FROM mc_status", (err, rows) => {
                if (err) reject(err);
                else resolve(rows);
            });
        });

        const isRunning = rows[0].isRunning;
        const channelID = client.guilds.cache.get(config.guildId);
        const textchannel = channelID.channels.cache.get("1199445783326507091");
        const message = await textchannel.messages.fetch("1199493614863134791");

        if (isRunning == 0 && lastState != 0) {
            const embed = new EmbedBuilder()
                .setColor(0xFF2D00)
                .setTitle(`The server is currently **Offline**`)
                .setFooter({ text: client.user.username, iconURL: client.user.displayAvatarURL() })
                .setTimestamp();
            await message.edit({ embeds: [embed] });
            lastState = 0
        } else if (isRunning == 1 && lastState != 1) {
            const embed = new EmbedBuilder()
                .setColor(0x1FFF00)
                .setTitle(`The server is currently **Online**`)
                .setFooter({ text: client.user.username, iconURL: client.user.displayAvatarURL() })
                .setTimestamp();
            await message.edit({ embeds: [embed] });
            lastState = 1
        }

        setTimeout(updateServerStatus, 5000)
    } catch (err) {
        console.error(err);
    }
}
const rest = new REST().setToken(config.token)

client.once("ready", () => {
    client.user.setPresence({
        status: "dnd",
        activities: [{
            name: "Watching over the servers",
            type: ActivityType.Custom,
        }]
    })
    console.log(`${client.user.username} szolgálatra kész`)
    giveawaybot.mainbot()

    setInterval(updateServerStatus, 5000);
    setInterval(addRole, 60000);
    setInterval(removeRole, 604800000);
    pingConnection()
    pingBot()
    main();
})

async function main()
{
    const commands = [
        {
            name: 'mcadd',
            description: 'Adds the minecraft username to the whitelist',
            options: [
                {
                    name: 'username',
                    description: 'Minecraft username',
                    type: 3,
                    required: true,
                },
                {
                    name: 'language',
                    description: 'Language',
                    type: 3,
                    required: true,
                    choices: [
                        {
                            name: 'Hungary',
                            value: "HU",
                        },
                        {
                            name: 'English',
                            value: "ENG",
                        },
                        {
                            name: 'German',
                            value: "DE",
                        },
                        {
                            name: 'Poland',
                            value: "PL",
                        },
                        {
                            name: 'Czech',
                            value: "CZ",
                        },
                    ]
                },
            ],
        },
        {
            name: 'subonly',
            description: 'Minecraft server sub-only change',
            options: [
                {
                    name: 'type',
                    description: 'New status',
                    type: 5,
                    required: true,
                },
            ],
        },
        {
            name: 'mcedit',
            description: 'Changes minecraft username in the whitelist',
            options: [
                {
                    name: 'newusername',
                    description: 'New minecraft username',
                    type: 3,
                    required: true,
                },
            ],
        },
        {
            name: 'setlang',
            description: 'Change language',
            options: [
                {
                    name: 'newlanguage',
                    description: 'New language',
                    type: 3,
                    required: true,
                    choices: [
                        {
                            name: 'Hungary',
                            value: "HU",
                        },
                        {
                            name: 'English',
                            value: "ENG",
                        },
                        {
                            name: 'German',
                            value: "DE",
                        },
                        {
                            name: 'Poland',
                            value: "PL",
                        },
                        {
                            name: 'Czech',
                            value: "CZ",
                        },
                    ]
                },
            ],
        },
    ];
    try {
        await rest.put(
			Routes.applicationGuildCommands(config.clientid, config.guildId),{ 
                body: commands, 
            }
		)
    } catch(err) {
        console.log(err.message);
    }
}

function getLanguage(userid) {
    return new Promise((resolve, reject) => {
        con.query(`SELECT Language FROM Adatok WHERE UserID='${userid}'`, (err, rows) => {
            if (err) reject(err);
            if (rows.length > 0) {
                resolve(rows[0].Language);
            } else {
                resolve("ENG");
            }
        });
    });
}

//let subOnlyStatus = true;

client.on("interactionCreate", async (interaction) => {
    if (interaction.isCommand()) { 
        if(interaction.channelId != "1201177388738949241" && interaction.channelId != "1199441220934570004" && interaction.channelId != "1201182537142255737") return
        const lang = await getLanguage(interaction.member.user.id)
        const langpackage = languages.find(l => l.langpack == lang)
        /*con.query(`SELECT subOnly FROM mc_status`, async (err, rows) => {
            if (err) throw err;
            if (rows[0].subOnly == '1') {
                subOnlyStatus = true;
            }
            else
            {
                subOnlyStatus = false;
            }
        })*/
        con.query(`SELECT UserID FROM Adatok WHERE isBanned=1 AND UserID='${interaction.member.user.id}'`, async (err, rows) => {
            if (err) throw err;
            if (rows.length > 0)
            {
                await interaction.reply({content: langpackage.banned})
            }
            else
            {
                if(interaction.commandName == "mcadd") {
                    if(Roles.some(roleID => interaction.member.roles.cache.has(roleID))) {
                        con.query(`SELECT MC_Name FROM Adatok WHERE UserID='${interaction.member.user.id}'`, async (err, rows) => {
                            if (err) throw err;
                            if(rows.length < 1)
                            {
                                con.query(`INSERT INTO Adatok(UserID, Username, MC_Name, isBanned, canPlay, needRoles, Language, LastChanged) VALUES ('${interaction.member.user.id}', '${interaction.member.user.username}', '${interaction.options.get("username").value}', '0', '1', '1', '${interaction.options.get("language").value}', NOW())`)
                                const type = interaction.options.get("language").value
                                const newlangpackage = languages.find(l => l.langpack == type)
                                await interaction.reply({content: newlangpackage.useradded})
                            }
                            else
                            {
                                await interaction.reply({content: langpackage.userexists})
                            }
                        })
                    }
                    else
                    {
                        con.query(`SELECT MC_Name FROM Adatok WHERE UserID='${interaction.member.user.id}'`, async (err, rows) => {
                            if (err) throw err;
                            if(rows.length < 1)
                            {
                                con.query(`INSERT INTO Adatok(UserID, Username, MC_Name, isBanned, canPlay, needRoles, Language, LastChanged) VALUES ('${interaction.member.user.id}', '${interaction.member.user.username}', '${interaction.options.get("username").value}', '0', '0', '1', '${interaction.options.get("language").value}', NOW())`)
                                const type = interaction.options.get("language").value
                                const newlangpackage = languages.find(l => l.langpack == type)
                                await interaction.reply({content: newlangpackage.useradded})
                            }
                            else
                            {
                                await interaction.reply({content: langpackage.userexists})
                            }
                        })
                    }
                }
                else if (interaction.commandName == "mcedit")
                {
                    con.query(`SELECT MC_Name FROM Adatok WHERE UserID='${interaction.member.user.id}'`, async (err, rows) => {
                    if (err) throw err;
                    if (rows.length > 0) {
                        con.query(`SELECT Hour(TIMEDIFF(DATE_ADD(LastChanged, INTERVAL 1 DAY), NOW())) AS 'TimeLeft_Hours', Minute(TIMEDIFF(DATE_ADD(LastChanged, INTERVAL 1 DAY), NOW())) AS 'TimeLeft_Minutes', Second(TIMEDIFF(DATE_ADD(LastChanged, INTERVAL 1 DAY), NOW())) AS 'TimeLeft_Seconds', TIMEDIFF(DATE_ADD(LastChanged, INTERVAL 1 DAY), NOW()) < 0 AS 'TimeLeft' FROM Adatok WHERE UserID='${interaction.member.user.id}'`, async (err, rows) => {
                            if (err) throw err;
                            if(rows[0].TimeLeft == '0') 
                            {
                                const timeLeftHours = rows[0].TimeLeft_Hours;
                                const timeLeftMinutes = rows[0].TimeLeft_Minutes;
                                const timeLeftSeconds = rows[0].TimeLeft_Seconds;
                                
                                await interaction.reply({ content: `${langpackage.timeleft.replace('${rows[0].TimeLeft_Hours}', timeLeftHours).replace('${rows[0].TimeLeft_Minutes}', timeLeftMinutes).replace('${rows[0].TimeLeft_Seconds}', timeLeftSeconds)}` });
                            }
                            else
                            {
                                con.query(`SELECT MC_Name FROM Adatok WHERE MC_Name='${interaction.options.get("newusername").value.trim()}' AND UserID!='${interaction.member.user.id}'`, async (err, rows) => {
                                    if (err) throw err;
                                    if (rows.length > 0)
                                    {
                                        await interaction.reply({content: langpackage.nameexists})
                                    }
                                    else
                                    {
                                        con.query(`SELECT MC_Name FROM Adatok WHERE UserID='${interaction.member.user.id}'`, async (err, rows) => {
                                            if (err) throw err;
                                            if (rows[0].MC_Name.trim() == interaction.options.get("newusername").value) {
                                                await interaction.reply({content: langpackage.samename})
                                            }
                                            else
                                            {
                                                con.query(`UPDATE Adatok SET MC_Name='${interaction.options.get("newusername").value.trim()}', LastChanged=NOW() WHERE UserID='${interaction.member.user.id}'`)
                                                await interaction.reply({content: langpackage.change})
                                            }
                                        })
                                    }
                                })
                            }
                        })
                    }
                    else
                    {
                        await interaction.reply({content: langpackage.notexists})
                    }
                })
                }
                else if (interaction.commandName == "subonly")
                {
                    const allowedUsers = ["211569770863001600", "311866028076302336"]

                    if(allowedUsers.some(userid => userid == interaction.member.user.id))
                    {
                        const type = interaction.options.getBoolean("type");

                        if (type)
                        {
                            con.query(`SELECT subOnly FROM mc_status`, async (err, rows) => {
                                if (err) throw err
                                if(rows[0].subOnly == 1)
                                {
                                    interaction.reply({content: "A szerver eddig is subonly volt."})
                                }
                                else
                                {
                                    con.query("UPDATE mc_status SET subOnly=1")
                                    interaction.reply({content: "A szerver mostmár subonly!"})
                                }
                            }) 
                        }
                        else
                        {
                            con.query(`SELECT subOnly FROM mc_status`, async (err, rows) => {
                                if (err) throw err
                                if(rows[0].subOnly == 0)
                                {
                                    interaction.reply({content: "A szerver eddig se volt subolny."})
                                }
                                else
                                {
                                    con.query("UPDATE mc_status SET subOnly=0")
                                    interaction.reply({content: "A szerver mostmár nem subonly!"})
                                }
                            }) 
                        }
                    }
                }
                else if (interaction.commandName == "setlang")
                {
                    con.query(`SELECT Language FROM Adatok WHERE UserID='${interaction.member.user.id}'`, async (err, rows) => {
                        if (err) throw err
                        if (rows.length > 0)
                        {
                            const type = interaction.options.get("newlanguage").value
                            if(rows[0].Language != type)
                            {
                                con.query(`UPDATE Adatok SET Language='${interaction.options.getString("newlanguage")}' WHERE UserID='${interaction.member.user.id}'`)
                                const newlangpackage = languages.find(l => l.langpack == type)
                                await interaction.reply({content: newlangpackage.langchanged})
                            }
                            else
                            {
                                await interaction.reply({content: langpackage.samelang})
                            }
                        }
                        else
                        {
                            await interaction.reply({content: langpackage.notexists})
                        }
                    })
                }
            }
        })
    }
})


client.on("guildMemberAdd", async (member) => {//1198246680361975850
    try
    {
        await rest.put(
            Routes.guildMemberRole(config.guildId, member.id, "1198246680361975850"),
            {body: {Roles: "1198246680361975850" }});
    } catch (error) 
    {
        console.log(error);
    }
})

client.login(config.token)
