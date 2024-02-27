function mainbot()
{
    const { Client, Events, GatewayIntentBits, ButtonBuilder, ActionRowBuilder, REST, Routes, EmbedBuilder, ActivityType, Collection, ButtonStyle, PermissionsBitField } = require("discord.js");
    const mysql = require('mysql')
    const config = require('./config.json')

    const client = new Client({intents: [GatewayIntentBits.Guilds, GatewayIntentBits.GuildMembers, GatewayIntentBits.GuildMessages, GatewayIntentBits.MessageContent]})

    let con = mysql.createConnection({
        host: config.SQLHOST,
        user: config.SQLUSER,
        password: config.SQLPASS,
        database: config.SQLDB,
    })

    con.connect(function(err) {
        if (err) throw err;
    })

    const rest = new REST().setToken(config.TOKEN);

    async function main()
    {
        const commands = [
            {
                name: "creategiv",
                description: "Creates a giveaway",
                options: [
                    {
                        name: "name",
                        description: "The giveaway name",
                        type: 3,
                        required: true,
                    },
                    {
                        name: "description",
                        description: "The giveaway description",
                        type: 3,
                        required: true,
                    },
                    {
                        name: "prize",
                        description: "The giveaway prize",
                        type: 3,
                        required: true,
                    },
                    {
                        name: "days",
                        description: "The giveaway duration in days",
                        type: 10,
                        required: true,
                    },
                    {
                        name: "hours",
                        description: "The giveaway duration in hours",
                        type: 10,
                        required: true,
                    },
                    {
                        name: "minutes",
                        description: "The giveaway duration in minutes",
                        type: 10,
                        required: true,
                    },
                    {
                        name: "seconds",
                        description: "The giveaway duration in seconds",
                        type: 10,
                        required: true,
                    },
                ],
            },
            {
                name: "deletegiv",
                description: "Deletes a giveaway",
                options: [
                    {
                        name: "name",
                        description: "The giveaway name",
                        type: 3,
                        required: true,
                    },
                ],
            },
            {
                name: "editgiv",
                description: "Edits the giveaway info",
                options: [
                    {
                        name: "giveaway",
                        description: "The giveaway name",
                        type: 3,
                        required: true,
                    },
                    {
                        name: "name",
                        description: "The giveaway name",
                        type: 3,
                    },
                    {
                        name: "description",
                        description: "The giveaway description",
                        type: 3,
                    },
                    {
                        name: "prize",
                        description: "The giveaway prize",
                        type: 3,
                    },
                    {
                        name: "days",
                        description: "The giveaway duration in days",
                        type: 10,
                    },
                    {
                        name: "hours",
                        description: "The giveaway duration in hours",
                        type: 10,
                    },
                    {
                        name: "minutes",
                        description: "The giveaway duration in minutes",
                        type: 10,
                    },
                    {
                        name: "seconds",
                        description: "The giveaway duration in seconds",
                        type: 10,
                    },
                ],
            },
            {
                name: "addrole",
                description: "Adds a role",
                options: [
                    {
                        name: "giveaway",
                        description: "The giveaway name",
                        type: 3,
                        required: true,
                    },
                    {
                        name: "name",
                        description: "The role name",
                        type: 9,
                        required: true,
                    },
                    {
                        name: "multiplier",
                        description: "The role multiplier in the giveaway",
                        type: 10,
                        required: true,
                    },
                ],
            },
            {
                name: "delrole",
                description: "Deletes a role",
                options: [
                    {
                        name: "giveaway",
                        description: "The giveaway name",
                        type: 3,
                        required: true,
                    },
                    {
                        name: "name",
                        description: "The role name",
                        type: 9,
                        required: true,
                    },
                ],
            },
            {
                name: "info",
                description: "Gets the giveaway info",
                options: [
                    {
                        name: "name",
                        description: "The giveaway name",
                        type: 3,
                        required: true,
                    },
                ],
            },
        ];

        for (let i = 0; i < Guilds.length; i++)
        {
            try {
                await rest.put(
                    Routes.applicationGuildCommands(config.CLIENTID, Guilds[i]),{ 
                        body: commands, 
                    }
                )
            
            } catch(err) {
                console.log(err);
            }
        }   
    }

    async function connectSQL()
    {
        con.ping((err) => {
            if (err) {
                console.error("Adatbázis kapcsolat megszakadt. Új kapcsolat létrehozása folyamatban...");
                con = mysql.createConnection({
                    host: config.SQLHOST,
                    user: config.env.SQLUSER,
                    password: config.env.SQLPASS,
                    database: config.env.SQLDB
                })
                con.connect((err) => {
                    if (err) {
                        console.error("Hiba keletkezett az újrapróbálkozás során. Hiba:", err);
                    } else {
                        console.log("Adatbázis kapcsolat újra létrehozva!");
                    }
                });
            }
            else
            {
                console.log("Adatbázis kapcsolat naprakész!")
            }
        });
        setTimeout(connectSQL, 600000)
    }

    let Guilds = [] //GuildID-s
    let Giveaways = new Map() //Giveawayek
    let Messages = new Map() //Üzenetek ID-ja
    let Roles = new Map() //Rolok
    let roleobject = {} //Role információ
    let Members = new Map() // Emberek
    let joinedMembers = new Map() //Játékosok a szorzóval

    function updateGuilds()
    {
        con.query("SELECT guildID FROM guilds", (err, rows) => {
            if (err) throw err;
            Guilds = []
            for (let row of rows)
            {
                Guilds.push(row.guildID)
            }
            main()
        })
        setTimeout(updateGuilds, 1800000)
    }

    function updateGiveaways()
    {
        con.query("SELECT guildID, name FROM giveaway a, guilds b WHERE a.guild = b.guildID", (err, rows) => {
            if (err) throw err;

            Giveaways.clear()
            if(rows.length > 0)
            {
                for (let row of rows)
                {
                    if (!Giveaways.has(row.guildID))
                    {
                        Giveaways.set(row.guildID, [row.name])
                    }
                    else
                    {
                        let values = Giveaways.get(row.guildID)
                        values.push([row.name])
                        Giveaways.set(row.guildID, values)
                    }
                }
            }
        })
        setTimeout(updateGiveaways, 1800000)
    }

    function updateMessages()
    {
        con.query("SELECT * FROM messages", (err, rows) => {
            if (err) throw err;
            
            Messages.clear()
            if(rows.length > 0)
            {
                for(let row of rows)
                {
                    if (!Messages.has(row.guild))
                    {
                        Messages.set(row.guild, [row.channelID, row.messageID])
                    }
                    else
                    {
                        let values = Messages.get(row.guild)
                        values.push([row.channelID, row.messageID])
                        Messages.set(row.guild, values)
                    }
                }
            }
        })
        setTimeout(updateMessages, 1800000)
    }

    function updateRoles()
    {
        con.query(`SELECT * FROM roles`, (err, rows) => {
            if (err) throw err;
            Roles.clear()
            roleobject = {}
            if(rows.length > 0)
            {
                for (let row of rows)
                {
                    const roleID = row.roleID
                    const multiplier = row.multiplier
                    if (!Roles.has(row.guild) && !roleobject.hasOwnProperty(row.guild))
                    {
                        Roles.set(row.guild, [row.roleID, row.multiplier])
                        roleobject[row.guild] = [{roleID, multiplier}]
                    }
                    else
                    {
                        let values = Roles.get(row.guild)
                        values.push([row.roleID, row.multiplier])
                        Roles.set(row.guild, values)
                        roleobject[row.guild].push({roleID, multiplier})
                    }
                }
            }
        })
        setTimeout(updateRoles, 1800000)
    }

    function updateDBRoles()
    {
        con.query(`SELECT * FROM members`, async (err, rows) => {
            if (err) throw err
            if (rows.length > 0)
            {
                for (const row of rows)
                {
                    const gd = await client.guilds.fetch(row.guild)
                    const channel = await gd.channels.fetch(row.channelID)
                    const member = await gd.members.fetch(row.userID)
                    const role = member.roles.cache.get(row.roleID)
                    if (role === undefined)
                    {
                        con.query(`DELETE FROM list WHERE guild='${gd.id}' AND channelID='${channel.id}' AND userID='${member.id}'`)
                        let pass = false
                        let roleInfo
                        let multiplier
                        con.query(`SELECT * FROM roles WHERE guild='${gd.id}' AND channelID='${channel.id}' ORDER BY roles.multiplier DESC`, async (err2, rows2) => {
                            if (err2) throw err2
                            if(rows2.length > 0)
                            {
                                for (const row2 in rows2)
                                {
                                    const memberhasanyrole = member.roles.cache.get(row2.roleID)
                                    if (memberhasanyrole)
                                    {
                                        pass = true
                                        roleInfo = gd.roles.fetch(row2.roleID)
                                        multiplier = row2.multiplier
                                        break
                                    }
                                }
                                if (pass)
                                {
                                    con.query(`UPDATE members SET roleID='${roleInfo.id}', roleName='${roleInfo.name}', multiplier='${multiplier}' WHERE userID='${member.id}'`)
                                    for(let i = 0; i < Number(multiplier);i++) con.query(`INSERT INTO list(guild, channelID, userID) VALUES ('${gd.id}', '${channel.id}', '${member.id}')`)
                                }
                            }
                        })
                    }
                }
            }
        })
        setTimeout(updateDBRoles, 10000)
    }

    function updateJoinedMembers()
    {
        con.query(`SELECT * FROM members`, (err, rows) => {
            if (err) throw err;

            joinedMembers.clear()
            if(rows.length > 0)
            {
                for (let row of rows)
                {
                    let addString = ""
                    if (!joinedMembers.has(row.guild))
                    {
                        for (let i = 0; i < Number(row.multiplier); i++)
                        {
                            addString += row.userID + ","
                        }
                        joinedMembers.set(row.guild, [row.channelID, addString.slice(0,-1), row.multiplier])
                    }
                    else
                    {
                        let values = joinedMembers.get(row.guild)
                        for (let i = 0; i < Number(row.multiplier); i++)
                        {
                            addString += row.userID + ","
                        }
                        values.push([row.channelID, addString.slice(0,-1), row.multiplier])
                        joinedMembers.set(row.guild, values)
                    }
                }
            }
            setTimeout(updateJoinedMembers, 60000)
        })
    }

    function updateMembers()
    {
        con.query("SELECT memberlist, guild FROM giveaway", (err, rows) => {
            if (err) throw err;

            Members.clear()
            if(rows.length > 0)
            {
                for (let row of rows)
                {
                    if (!Members.has(row.guild))
                    {
                        Members.set(row.guild, [row.memberlist])
                    }
                    else
                    {
                        let values = Members.get(row.guild)
                        values.push(row.memberlist)
                        Members.set(row.guild, values)
                    }
                }
            }
        })
        setTimeout(updateMembers, 1800000)
    }

    function announceWinner()
    {
        con.query(`SELECT TIMEDIFF(duration, NOW()) AS "ido", guild, channelID FROM giveaway LIMIT 1`, async (err, rows) => {
            if (err) throw err

            if(rows.length > 0 && rows[0].ido.startsWith('-'))
            {
                con.query(`SELECT userID FROM list WHERE guild='${rows[0].guild}' AND channelID='${rows[0].channelID}' ORDER BY RAND() LIMIT 1`, async (err2, rows2) => {
                    if (err2) throw err2
                    if (rows2.length > 0)
                    {
                        const gd = await client.guilds.fetch(rows[0].guild)
                        const ch = await gd.channels.fetch(rows[0].channelID)
                        const user = await gd.members.fetch(rows2[0].userID)
                        await ch.send(`${user} has won the giveaway! GG`)
                        con.query(`DELETE FROM roles WHERE guild='${rows[0].guild}' AND channelID='${rows[0].channelID}'`)
                        con.query(`DELETE FROM messages WHERE guild='${rows[0].guild}' AND channelID='${rows[0].channelID}'`)
                        con.query(`DELETE FROM members WHERE guild='${rows[0].guild}' AND channelID='${rows[0].channelID}'`)
                        con.query(`DELETE FROM giveaway WHERE guild='${rows[0].guild}' AND channelID='${rows[0].channelID}'`)
                        con.query(`DELETE FROM list WHERE guild='${rows[0].guild}' AND channelID='${rows[0].channelID}'`)
                        updateRoles()
                        updateGiveaways()
                        updateJoinedMembers()
                        updateMembers()
                        updateMessages()
                        roleobject = null
                        return
                    }
                }) 
            }
        })
        setTimeout(announceWinner, 2000)
    }

    function updatePanel()
    {
        con.query(`SELECT name, description, prize, members, duration, messageID, b.channelID, b.guild FROM messages a, giveaway b WHERE a.guild = b.guild AND a.channelID = b.channelID`, async (err, rows) => {
            if (err) throw err;

            if(rows.length > 0)
            {
                for (let row of rows)
                {
                    const gd = await client.guilds.fetch(row.guild)
                    const ch = await gd.channels.fetch(row.channelID)
                    const msg = await ch.messages.fetch(row.messageID)

                    const date = new Date(row.duration)
                    date.setHours(date.getHours()+1)
                    const format = date.toLocaleTimeString('hu-HU', { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' });

                    const embed = new EmbedBuilder()
                        .setTitle(`${row.name} Giveaway`)
                        .setColor(0x00FFF3)
                        .setDescription(row.description)
                        .addFields(
                            {name: "Prize", value: String(row.prize), inline: true},
                            {name: "Joined members", value: String(row.members), inline: true},
                            {name: "Expiration", value: format.trim()}
                        )
                        .setTimestamp()
                        .setFooter({ text: client.user.username, iconURL: client.user.displayAvatarURL() })

                    const btn = new ButtonBuilder()
                        .setCustomId("join")
                        .setEmoji("🎉")
                        .setStyle(ButtonStyle.Primary)

                    const rowline = new ActionRowBuilder()
                        .addComponents(btn)

                    msg.edit({embeds: [embed], components: [rowline]})
                }
            }
        })

        setTimeout(updatePanel, 3000)
    }

    client.once(Events.ClientReady, async () => {
        client.user.setPresence({
            status: "dnd",
            activities: [{
                name: "Managing giveaways",
                type: ActivityType.Custom
            }]
        })

        console.log(`${client.user.displayName} Készen áll!`)

        connectSQL()
        updateGuilds()
        updateGiveaways()
        updateMessages()
        updateRoles()
        updateMembers()
        announceWinner()
        updatePanel()
        updateDBRoles()
    })

    function formatDate(date) {
        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const day = date.getDate().toString().padStart(2, '0');
        let hours = date.getHours() + 1
        hours = hours.toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        const seconds = date.getSeconds().toString().padStart(2, '0');
    
        return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
    }

    let cont = false

    client.on(Events.InteractionCreate, async (interaction) => {
        if (interaction.isChatInputCommand())
        {
            if (interaction.member.permissions.has(PermissionsBitField.Flags.Administrator))
            {
                for (guild of Guilds)
                {
                    if(guild == interaction.guild.id)
                    {
                        cont = true
                        break
                    }
                }
                if (cont)
                {
                    if(interaction.commandName === "creategiv")
                    {
                        if (interaction.options.get("name").value != Giveaways.get(interaction.guild.id)) {
                            let days = interaction.options.getNumber("days");
                            let hours = interaction.options.getNumber("hours");
                            let minutes = interaction.options.getNumber("minutes");
                            let seconds = interaction.options.getNumber("seconds");
                    
                            let expirationDate = new Date();
                            expirationDate.setDate(expirationDate.getDate() + days);
                            expirationDate.setHours(expirationDate.getHours() + hours);
                            expirationDate.setMinutes(expirationDate.getMinutes() + minutes);
                            expirationDate.setSeconds(expirationDate.getSeconds() + seconds);
                    
                            let formattedExpirationDate = expirationDate.toISOString().slice(0, 19).replace('T', ' ');
                    
                            con.query(`INSERT INTO giveaway(name, description, prize, duration, guild, channelID, members) VALUES ('${interaction.options.get("name").value}', '${interaction.options.get("description").value}', '${interaction.options.get("prize").value}', '${formattedExpirationDate}', '${interaction.guild.id}', '${interaction.channel.id}', 0)`);
                            updateGiveaways()

                            const embed = new EmbedBuilder()
                            .setTitle(`${interaction.options.get("name").value} Giveaway`)
                            .setColor(0x00FFF3)
                            .setDescription(interaction.options.get("description").value)
                            .addFields(
                                {name: "Prize", value: interaction.options.get("prize").value, inline: true},
                                {name: "Joined members", value: "0", inline: true},
                                {name: "Expiration", value: formattedExpirationDate}
                            )
                            .setTimestamp()
                            .setFooter({ text: client.user.username, iconURL: client.user.displayAvatarURL() })

                            /*const btn = new ButtonBuilder()
                                .setCustomId("join")
                                .setEmoji("🎉")
                                .setStyle(ButtonStyle.Primary)

                            const row = new ActionRowBuilder()
                                .addComponents(btn) */                       

                            const msg = await interaction.channel.send({embeds: [embed]})

                            await interaction.reply({content: "Giveaway létrehozva", ephemeral: true})    

                            con.query(`INSERT INTO messages(messageID, channelID, guild) VALUES ('${msg.id}', '${interaction.channel.id}', '${interaction.guild.id}')`)
                            updateMessages()
                        }
                        else
                        {
                        await interaction.reply({content: "Már létezik ilyen giveaway!", ephemeral: true})
                        }
                    }
                    else if (interaction.commandName === "deletegiv")
                    {
                        updateRoles()
                        updateGiveaways()
                        if(Giveaways.get(interaction.guild.id) && Giveaways.get(interaction.guild.id).includes(interaction.options.get("name").value))
                        {
                            con.query(`SELECT messageID, channelID, guild FROM messages WHERE channelID='${interaction.channel.id}' AND guild='${interaction.guild.id}'`, async (err, rows) => {
                                if (err) throw err
                                if(rows.length > 0)
                                {
                                    for(let row of rows)
                                    {
                                        const gd = await interaction.guild.fetch(row.guild)
                                        const ch = await gd.channels.fetch(row.channelID)
                                        const msg = await ch.messages.fetch(row.messageID)
                                        msg.delete()
                                    }
                                }
                            })

                            con.query(`DELETE FROM giveaway WHERE name='${interaction.options.get("name").value}' AND guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}'`)
                            con.query(`DELETE FROM messages WHERE channelID='${interaction.channel.id}' AND guild='${interaction.guild.id}'`)
                            con.query(`DELETE FROM roles WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}'`)
                            con.query(`DELETE FROM members WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}'`)
                            updateGiveaways()
                            updateMessages()
                            updateRoles()
                            updateMembers()
                            updateJoinedMembers()
                            updatePanel()

                            await interaction.reply({content: "Giveaway törölve!", ephemeral: true})
                        }
                        else
                        {
                            await interaction.reply({content: "Nincs ilyen giveaway!", ephemeral: true})
                        }
                    }
                    else if (interaction.commandName === "editgiv")
                    {
                        updateGiveaways()
                        if(Giveaways.get(interaction.guild.id) && Giveaways.get(interaction.guild.id).includes(interaction.options.get("giveaway").value))
                        {
                            let updates = []
                            let pass = false
                            let days = 0
                            let hours = 0
                            let minutes = 0
                            let seconds = 0
                            interaction.options.data.forEach((option) =>
                            {
                                switch (option.name)
                                {
                                    case "name":
                                        updates.push(`name = '${option.value}'`)
                                        pass = true
                                    break;

                                    case "description":
                                        updates.push(`description = '${option.value}'`)
                                        pass = true
                                    break;

                                    case "prize":
                                        updates.push(`prize = '${option.value}'`)
                                        pass = true
                                    break;

                                    case "days":
                                        days = Number(option.value)
                                        pass = true
                                    break;

                                    case "hours":
                                        hours = Number(option.value)
                                        pass = true
                                    break;

                                    case "minutes":
                                        minutes = Number(option.value)
                                        pass = true
                                    break;

                                    case "seconds":
                                        seconds = Number(option.value)
                                        pass = true
                                    break;
                                }
                            })
                            if (!pass) 
                            {
                                interaction.reply({content: "Semmi sem változott!", ephemeral: true}); 
                                return
                            }
                            con.query(`SELECT duration FROM giveaway WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}'`, async (err, rows) => {
                                if (err) throw err
                                const newDate = new Date(rows[0].duration)
                                const currentDate = new Date()
                                if (days !== 0) newDate.setDate(currentDate.getDate() + days)
                                else newDate.setDate(newDate.getDate())
                                if (hours !== 0) newDate.setHours(currentDate.getHours() + hours)
                                else newDate.setHours(newDate.getHours())
                                if (minutes !== 0) newDate.setMinutes(currentDate.getMinutes() + minutes)
                                else newDate.setMinutes(newDate.getMinutes())
                                if (seconds !== 0) newDate.setSeconds(currentDate.getSeconds() + seconds)
                                else newDate.setSeconds(newDate.getSeconds())
                                let formattedExpirationDate = newDate.toISOString().slice(0, 19).replace('T', ' ');
                                updates.push(`duration = '${formattedExpirationDate}'`)
                                con.query(`UPDATE giveaway SET ${updates.join(', ')} WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}'`)
                                await interaction.reply({content: "Adatok megváltoztatva!", ephemeral: true})
                                updateGiveaways()
                            })
                        }
                        else
                        {
                            await interaction.reply({content: "Nincs ilyen giveaway!", ephemeral: true})
                        }
                    }
                    else if (interaction.commandName === "addrole")
                    {
                        updateRoles()
                        updateGiveaways()
                        if (Giveaways.get(interaction.guild.id) && Giveaways.get(interaction.guild.id).includes(interaction.options.get("giveaway").value))
                        {
                            let pass = true
                            Roles.forEach((value, key) => {
                                if(key == interaction.guild.id)
                                {
                                    value.forEach(val => {
                                        if (val.includes(interaction.guild.roles.cache.get(interaction.options.get("name").value).id)) pass = false
                                    })
                                }
                            })
                            if(pass)
                            {
                                let split = interaction.guild.roles.cache.get(interaction.options.get("name").value).name.includes('｜') ? interaction.guild.roles.cache.get(interaction.options.get("name").value).name.split('｜')[1] : interaction.guild.roles.cache.get(interaction.options.get("name").value).name
                                con.query(`INSERT INTO roles(name, roleID, channelID, multiplier, guild) VALUES ('${split}', '${interaction.guild.roles.cache.get(interaction.options.get("name").value).id}', '${interaction.channel.id}', '${interaction.options.get("multiplier").value}', '${interaction.guild.id}')`)
                                await interaction.reply({content: `<@&${interaction.guild.roles.cache.get(interaction.options.get("name").value).id}> sikeresen hozzáadva a(z) **${interaction.options.get("giveaway").value}** giveawayhez, **${interaction.options.get("multiplier").value}**x szorzóval!`, ephemeral: true})
                            }
                            else
                            {
                                await interaction.reply({content: "Ez a role már hozzá van adva!", ephemeral: true})
                            }
                        }
                        else
                        {
                            await interaction.reply({content: "Nincs ilyen giveaway!", ephemeral: true})
                        }
                    }
                    else if (interaction.commandName === "delrole")
                    {
                        updateRoles()
                        if (Giveaways.get(interaction.guild.id) && Giveaways.get(interaction.guild.id).includes(interaction.options.get("giveaway").value))
                        {
                            let pass = true
                            Roles.forEach((value, key) => {
                                if(key == interaction.guild.id)
                                {
                                    value.forEach(val => {
                                        if (val.includes(interaction.guild.roles.cache.get(interaction.options.get("name").value).id)) pass = false
                                    })
                                }
                            })

                            if (pass)
                            {
                                con.query(`DELETE FROM roles WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}' AND roleID='${interaction.guild.roles.cache.get(interaction.options.get("name").value).id}'`)
                                updateRoles()
                                await interaction.reply({content: `<@&${interaction.guild.roles.cache.get(interaction.options.get("name").value).id}> törölve!`, ephemeral: true})
                            }
                            else
                            {
                                await interaction.reply({content: "Ez a role nincs hozzáadva!", ephemeral: true})
                            }
                        }
                        else
                        {
                            await interaction.reply({content: "Nincs ilyen giveaway!", ephemeral: true})
                        }
                    }
                    else if (interaction.commandName === "info")
                    {
                        if(Giveaways.get(interaction.guild.id) && Giveaways.get(interaction.guild.id).includes(interaction.options.get("name").value))
                        {
                            let expire;
                            let membercount = 0;
                            let members = []
                            let roles = []
                            let roleIDs = []
                            let multipliers = []
                            let memberRoles = []

                            con.query(`SELECT duration, members, memberlist, LENGTH(memberlist) as "hossz" FROM giveaway WHERE channelID='${interaction.channel.id}' AND guild='${interaction.guild.id}'`, async (err, rows) => {
                                if (err) throw err;

                                let seperate = []
                                let leng

                                for (let row of rows)
                                {
                                    expire = formatDate(row.duration)
                                    membercount = Number(row.members)
                                    seperate.push(row.memberlist)
                                    leng = row.hossz
                                }

                                await interaction.guild.members.fetch()
                                await interaction.guild.roles.fetch()

                                if (leng > 0)
                                {
                                    members.push(seperate.toString().slice(0,-1).split(',').map(m => {
                                        const member = interaction.guild.members.cache.get(m.trim())
                                        return member ? member.user : "Unknown member"
                                    }).join('\n'))
                                }
                                else members.push("None")
                                
                                con.query(`SELECT * FROM roles WHERE channelID='${interaction.channel.id}' AND guild='${interaction.guild.id}'`, async (err, rows) => {
                                    if (err) throw err;
                                    
                                    if(rows.length > 0)
                                    {
                                        for(let row of rows) 
                                        {
                                            roles.push(`<@&${row.roleID}>`)
                                            roleIDs.push(row.roleID)
                                            multipliers.push(row.multiplier)
                                        }
                                    }
                                    else
                                    {
                                        roles.push("None")
                                        roleIDs.push("None")
                                        multipliers.push("None")
                                    }

                                    if (!roleIDs.includes("None") && !members.includes("None"))
                                    {
                                        memberRoles.push(seperate.toString().slice(0,-1).split(',').map(m => {
                                            const member = interaction.guild.members.cache.get(m.trim())
                                            const role = member.roles.cache.find(r => roleIDs.includes(r.id))
                                            return role ? `<@&${role.id}>` : "None"
                                        }).join('\n'))
                                    }
                                    else
                                    {
                                        memberRoles.push("No multiplied role")
                                    }
                                    
                                    const embed = new EmbedBuilder()
                                    .setTitle(`${interaction.options.get("name").value} Information`)
                                    .addFields(
                                        { name: "Roles", value: roles.join('\n'), inline: true},
                                        { name: "Multiplier", value: `**${multipliers.join('\n')}**`, inline: true},
                                        { name: "Expire", value: `**${expire}**`},
                                        { name: "Membercount", value: `**${membercount}**`},
                                        { name: "Members", value: members.join('\n'), inline: true},
                                        { name: "Role", value: memberRoles.join('\n'), inline: true},
                                    )
                                    .setTimestamp()
                                    .setFooter({ text: client.user.username, iconURL: client.user.displayAvatarURL() })
                                    .setColor(0x00FF1F)
                                    await interaction.reply({content: "Lekérdezve", ephemeral: true})
                                    await interaction.channel.send({embeds: [embed]})
                                    /*setTimeout(() => {
                                        embedmessage.delete()
                                    }, 20000)*/
                            })

                            })
                        }
                        else
                        {
                            await interaction.reply({content: "Nincs ilyen giveaway!", ephemeral: true})
                        }
                    }
                }
                else
                {
                    await interaction.reply({content: "Nincs fent ez a szerver az adatbázisba!", ephemeral: true})
                }
            }
        }
        else if (interaction.isButton())
        {
            await interaction.deferReply({ephemeral: true})
            updateGiveaways()
            updateJoinedMembers()
            updateMembers()
            updateRoles()
            const inthegiveaway = await isInTheGiveaway(interaction.guild.id, interaction.channel.id, interaction.member.id)
            if (inthegiveaway)
            {
                con.query(`UPDATE giveaway SET memberlist=REPLACE(memberlist, '${interaction.member.id},', ''), members = members-1 WHERE channelID='${interaction.channel.id}' AND guild='${interaction.guild.id}'`)
                con.query(`DELETE FROM members WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}'`)
                con.query(`DELETE FROM list WHERE guild='${interaction.guild.id}' AND channelID='${interaction.channel.id}' AND userID='${interaction.member.id}'`)
                updateMembers()
                updateJoinedMembers()
                //updatePanel()
                await interaction.editReply({content: "You have left the giveaway!"})
                const msg = await interaction.channel.send({content: `${interaction.member.user} has left the giveaway!`})
                setTimeout(() => {
                    msg.delete()
                }, 2500)
            }
            else
            {
                updateRoles()
                let pass = false
                let roleprop
                let multiplier = 0
                const rows = roleobject[interaction.guild.id]
                if (rows)
                {
                    for (let row of Object.values(rows))
                    {
                    if(interaction.member.roles.cache.has(row.roleID))
                        {
                            pass = true
                            roleprop = interaction.guild.roles.cache.get(row.roleID)
                            multiplier = row.multiplier
                            break
                        }
                    }
                }
                if(pass)
                {
                    con.query(`UPDATE giveaway SET memberlist = IFNULL(CONCAT(memberlist, '${interaction.member.id},'), '${interaction.member.id},'), members = members + 1 WHERE channelID='${interaction.channel.id}' AND guild='${interaction.guild.id}'`)
                    con.query(`INSERT INTO members(userID, user, roleID, roleName, multiplier, channelID, guild) VALUES ('${interaction.member.id}', '${interaction.member.user.username}', '${roleprop.id}', '${roleprop.name}', '${multiplier}', '${interaction.channel.id}', '${interaction.guild.id}')`)
                    for (let i = 0; i < Number(multiplier); i++) con.query(`INSERT INTO list(guild, channelID, userID) VALUES ('${interaction.guild.id}', '${interaction.channel.id}', '${interaction.member.id}')`)
                    updateMembers()
                    updateJoinedMembers()
                    //updatePanel()
                    //const msg = await interaction.channel.send({content: `${interaction.member.user} has joined the giveaway! **(${multiplier}x Chance due to <@&${roleprop.id}>)**`})
                    const msg = await interaction.channel.send({content: `${interaction.member.user} has joined the giveaway! **(${multiplier}x Chance)**`})
                    setTimeout(() => {
                        msg.delete()
                    }, 2500)
                    await interaction.editReply({content: "You have succesfully joined the giveaway!"})
                }
                else
                {
                    await interaction.editReply({content: "You can't join the giveaway!"})
                }
            }
        }
    })

    function isInTheGiveaway(guild, channel, member)
    {
        return new Promise((resolve, reject) => {
            con.query(`SELECT memberlist, members FROM giveaway WHERE memberlist LIKE '%${member}%' AND channelID='${channel}' AND guild='${guild}'`, (err, rows) => {
                if (err) reject(err)
                if(rows.length > 0)
                {
                    resolve(true)
                }
                else
                {
                    resolve(false)
                }
            })
        })
    }


    client.on(Events.GuildCreate, (guild) => {
        con.query(`SELECT * FROM guilds WHERE guildID='${guild.id}'`, (err, rows) => {
            if (err) throw err;
            if(rows.length === 0)
            {
                con.query(`INSERT INTO guilds (guildID, guildName) VALUES ('${guild.id}', '${guild.name}')`)
                updateGuilds()
            }
        })
    })

    client.on(Events.GuildDelete, (guild) => {
        con.query(`SELECT * FROM guilds WHERE guildID='${guild.id}'`, (err, rows) => {
            if (err) throw err;
            if(rows.length > 0)
            {
                con.query(`DELETE FROM guilds WHERE guildID='${guild.id}'`)
                let i = Guilds.findIndex(index => index === guild.id)
                if (i !== -1) Guilds.splice(i,1)
            }
        })
    })
    client.login(config.TOKEN)
}

module.exports = {mainbot}


