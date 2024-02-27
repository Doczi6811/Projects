package me.doczi;

import org.bukkit.Bukkit;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;

public class Commands implements CommandExecutor {

    private ZsombeyEvent plugin;
    public Commands(ZsombeyEvent plugin)
    {
        this.plugin = plugin;
    }
    @Override
    public boolean onCommand(CommandSender sender, Command cmd, String label, String[] args)
    {
        boolean isPlayer = false;
        boolean isEvent = false;

        if (!plugin.eventname.equalsIgnoreCase("")) isEvent = true;
        if (sender instanceof Player) isPlayer = true;

        if(cmd.getName().equalsIgnoreCase("event"))
        {
            if(args.length > 0)
            {
                String subcmd = args[0].toLowerCase();

                if(!isPlayer)
                {
                    sender.sendMessage("§7[§6Event§7] §cOnly players can use this command!");
                    return false;
                }

                switch (subcmd)
                {
                    case "join":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.join"))
                        {
                            if(!plugin.eventJoinable)
                            {
                                sender.sendMessage("§7[§6Event§7] §cYou can't join to the event because it's closed!");
                                return false;
                            }

                            if(plugin.deniedplayers.contains(sender.getName()))
                            {
                                sender.sendMessage("§7[§6Event§7] §cYou can't join to the event because you are denied!");
                                return false;
                            }

                            if(plugin.max > 0 && plugin.players.size() == plugin.max && !sender.hasPermission("zsardcore.event.bypass"))
                            {
                                sender.sendMessage("§7[§6Event§7] §cYou can't join to the event because the event is full!");
                                return false;
                            }

                            if(!plugin.players.contains(sender.getName()))
                            {
                                plugin.players.add(sender.getName());
                                sender.sendMessage("§7[§6Event§7] §aYou have been joined to the event!");
                                if (plugin.max == 0)
                                {
                                    Bukkit.broadcastMessage("§7[§6Event§7] §b" + sender.getName() + " §ahas joined to the event.");
                                }
                                else
                                {
                                    Bukkit.broadcastMessage("§7[§6Event§7] §b" + sender.getName() + " §ahas joined to the event. §b(" + plugin.players.size() + "/"+ plugin.max + ")");
                                }
                            }
                            else
                            {
                                sender.sendMessage("§7[§6Event§7] §bYou have already joined to the event!");
                            }
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "leave":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.leave"))
                        {
                            if(plugin.players.contains(sender.getName()))
                            {
                                plugin.players.remove(sender.getName());
                                sender.sendMessage("§7[§6Event§7] §aYou have left the event!");
                                if (plugin.max == 0)
                                {
                                    Bukkit.broadcastMessage("§7[§6Event§7] §b" + sender.getName() + " §ahas left the event.");
                                }
                                else
                                {
                                    Bukkit.broadcastMessage("§7[§6Event§7] §b" + sender.getName() + " §ahas left the event. §b(" + plugin.players.size() + "/"+ plugin.max + ")");
                                }
                            }
                            else
                            {
                                sender.sendMessage("§7[§6Event§7] §bYou haven't joined to the event!");
                            }
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "list":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        StringBuilder stringBuilder = new StringBuilder();

                        for (String player : plugin.players)
                        {
                            stringBuilder.append("§b"+player+"§a, ");
                        }
                        if(stringBuilder.length() > 0) stringBuilder.deleteCharAt(stringBuilder.length()-2);

                        if(sender.hasPermission("zsardcore.event.list"))
                        {
                            if(!plugin.players.isEmpty())
                            {
                                sender.sendMessage("§7[§6Event§7] §aJoined players: " + stringBuilder.toString());
                            }
                            else
                            {
                                sender.sendMessage("§7[§6Event§7] §bNo one joined the event yet!");
                            }
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "create":
                       if(sender.hasPermission("zsardcore.event.create"))
                       {
                           if (args.length < 2 || args.length > 3) {
                               sender.sendMessage("§7[§6Event§7] §bUsage: §d/event create <eventname>");
                               return false;
                           }

                           if(!plugin.eventname.equals("")) {
                               sender.sendMessage("§7[§6Event§7] §cAn event has already been created!");
                               return false;
                           }

                           if(!args[1].equals(""))
                           {
                               if(args.length == 3 && !args[2].equals("")) plugin.max = Integer.parseInt(args[2]);
                               plugin.eventname = args[1];
                               sender.sendMessage("§7[§6Event§7] §aYou have succesfully created §b" + plugin.eventname + "§a.");
                               Bukkit.broadcastMessage("§7[§6Event§7] §aA new event has been created. Type §b/event join §ato participate.");
                           }
                           else
                           {
                               sender.sendMessage("§7[§6Event§7] §cYou have to give a name to the event without spaces!");
                           }
                       }
                       else
                       {
                           sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                       }
                    break;

                    case "delete":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.delete"))
                        {
                            if (args.length != 2) {
                                sender.sendMessage("§7[§6Event§7] §bUsage: §d/event delete <eventname>");
                            }
                            if(!args[1].equals("") && args[1].equals(plugin.eventname))
                            {
                                sender.sendMessage("§7[§6Event§7] §aYou have succesfully deleted §b" + plugin.eventname + "§a.");
                                plugin.eventname = "";
                                plugin.max = 0;
                            }
                            else
                            {
                                sender.sendMessage("§7[§6Event§7] §cYou have to name the existing event name!");
                            }
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "close":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(!plugin.eventJoinable)
                        {
                            sender.sendMessage("§7[§6Event§7] §bThe event is already closed!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.close"))
                        {
                            plugin.eventJoinable = false;
                            sender.sendMessage("§7[§6Event§7] §aYou have succesfully closed the event!");
                            Bukkit.broadcastMessage("§7[§6Event§7] §cThe event has been closed. Now you can't join the event.");
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "open":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(plugin.eventJoinable)
                        {
                            sender.sendMessage("§7[§6Event§7] §bThe event is already opened!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.open"))
                        {
                            plugin.eventJoinable = true;
                            sender.sendMessage("§7[§6Event§7] §aYou have succesfully opened the event!");
                            Bukkit.broadcastMessage("§7[§6Event§7] §aThe event has been opened. Now you can join the event again.");
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "deny":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.deny"))
                        {
                            if (args.length != 2) {
                                sender.sendMessage("§7[§6Event§7] §bUsage: §d/event deny <player>");
                                return false;
                            }

                            Player target = Bukkit.getServer().getPlayerExact(args[1]);
                            if(target == null)
                            {
                                sender.sendMessage("§7[§6Event§7] §cThe player is not online!");
                                return false;
                            }

                            if(target.hasPermission("zsardcore.event.bypass"))
                            {
                                sender.sendMessage("§7[§6Event§7] §cThe player can't be denied!");
                                return false;
                            }

                            if(plugin.deniedplayers.contains(target.getName())){
                                sender.sendMessage("§7[§6Event§7] §bThe player is already denied!");
                                return false;
                            }

                            plugin.deniedplayers.add(target.getName());
                            sender.sendMessage("§7[§6Event§7] §aYou have succesfully denied §b"+target.getName());
                            target.sendMessage("§7[§6Event§7] §cYou have been denied from the current event by: §b!" +sender.getName());

                            if(plugin.players.contains(target.getName()))
                            {
                                plugin.players.remove(target.getName());
                                sender.sendMessage("§7[§6Event§7] §b"+target.getName()+" §ahave been removed from the event!");
                                target.sendMessage("§7[§6Event§7] §cYou have been removed from the event because you are denied!");
                            }
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "allow":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.allow"))
                        {
                            if (args.length != 2) {
                                sender.sendMessage("§7[§6Event§7] §bUsage: §d/event allow <player>");
                                return false;
                            }

                            Player target = Bukkit.getServer().getPlayerExact(args[1]);
                            if(target == null)
                            {
                                sender.sendMessage("§7[§6Event§7] §cThe player is not online!");
                                return false;
                            }

                            if(!plugin.deniedplayers.contains(target.getName())){
                                sender.sendMessage("§7[§6Event§7] §cThe player is not denied!");
                                return false;
                            }

                            plugin.deniedplayers.remove(target.getName());
                            sender.sendMessage("§7[§6Event§7] §aYou have succesfully allowed §b"+target.getName());
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;

                    case "limit":
                        if(!isEvent)
                        {
                            sender.sendMessage("§7[§6Event§7] §cThere isn't any ongoing event right now!");
                            return false;
                        }

                        if(sender.hasPermission("zsardcore.event.limit"))
                        {
                            if (args.length != 2) {
                                sender.sendMessage("§7[§6Event§7] §bUsage: §d/event limit <number>");
                                return false;
                            }

                            if(Integer.parseInt(args[1]) == 0)
                            {
                                if(plugin.max == 0)
                                {
                                    sender.sendMessage("§7[§6Event§7] §cThe limit is already §bunlimited!");
                                    return false;
                                }

                                plugin.max = 0;
                                sender.sendMessage("§7[§6Event§7] §aYou have succesfully changed the event player capacity to §bunlimited§a!");
                            }
                            else if(Integer.parseInt(args[1]) > 0)
                            {
                                if(plugin.max == Integer.parseInt(args[1]))
                                {
                                    sender.sendMessage("§7[§6Event§7] §cThe limit is already set to §b" + plugin.max + "§c.");
                                    return false;
                                }

                                plugin.max = Integer.parseInt(args[1]);
                                sender.sendMessage("§7[§6Event§7] §aYou have succesfully changed the event player capacity to §b"+args[1]+"§a!");
                            }
                            else
                            {
                                sender.sendMessage("§7[§6Event§7] §cThe limit can't be lower than 0!");
                            }
                        }
                        else
                        {
                            sender.sendMessage("§7[§6Event§7] §cYou have no right to use this command!");
                        }
                    break;
                }
            }
            else
            {
                sender.sendMessage("§7[§6Event§7] §bCommands");
                sender.sendMessage("§eAliases: event, events, e");
                sender.sendMessage("§d/"+ cmd.getName() +" §7| §aList the commands");
                sender.sendMessage("§d/"+ cmd.getName() +" join §7| §aJoins to the event");
                sender.sendMessage("§d/"+ cmd.getName() +" leave §7| §aLeaves the event");
                sender.sendMessage("§d/"+ cmd.getName() +" list §7| §aLists the joined players");
                if(sender.hasPermission("zsardcore.event.create")) sender.sendMessage("§d/"+ cmd.getName() +" create <eventname> [limit] §7| §aCreates an event §b(Default limit: unlimited)");
                if(sender.hasPermission("zsardcore.event.delete")) sender.sendMessage("§d/"+ cmd.getName() +" delete <eventname> §7| §aDeletes an event");
                if(sender.hasPermission("zsardcore.event.open")) sender.sendMessage("§d/"+ cmd.getName() +" open §7| §aOpen the event for joining");
                if(sender.hasPermission("zsardcore.event.close")) sender.sendMessage("§d/"+ cmd.getName() +" close §7| §aCloses the event for joining");
                if(sender.hasPermission("zsardcore.event.deny")) sender.sendMessage("§d/"+ cmd.getName() +" deny §7| §aDenies a player from the current event");
                if(sender.hasPermission("zsardcore.event.allow")) sender.sendMessage("§d/"+ cmd.getName() +" allow §7| §aAllows the player to current event");
                if(sender.hasPermission("zsardcore.event.limit")) sender.sendMessage("§d/"+ cmd.getName() +" limit §7| §aSet the event player limit §b(Default: 0 = unlimited)");
                if(sender.hasPermission("zsardcore.event.bypass")) sender.sendMessage("§AYou are immune to deny and you can join an event even it is full!");
            }
        }
        return true;
    }
}
