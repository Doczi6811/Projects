package me.doczi;

import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;

import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class Command implements CommandExecutor {

    private ZsombeyWhitelist plugin;

    public Command(ZsombeyWhitelist plugin)
    {
        this.plugin = plugin;
    }
    @Override
    public boolean onCommand(CommandSender sender, org.bukkit.command.Command cmd, String label, String[] args)
    {
        if(cmd.getName().equalsIgnoreCase("subonly")) {
            if (sender.hasPermission("zsardcore.server.subonly")) {
                if (args.length == 1) {
                    if (args[0].equalsIgnoreCase("false")) {
                        plugin.openConnection();
                        try {
                            PreparedStatement sql = plugin.connection.prepareStatement("SELECT subOnly from mc_status");
                            ResultSet rs = sql.executeQuery();
                            if (rs.next()) {
                                if (rs.getInt(1) == 1) {
                                    PreparedStatement sql2 = plugin.connection.prepareStatement("UPDATE mc_status SET subOnly='0'");
                                    sql2.executeUpdate();
                                    sql2.close();
                                    sender.sendMessage("§aA szerver mostantól §cnem §asub-only!");
                                } else {
                                    sender.sendMessage("§cA szerver eddig is nem sub-only volt.");
                                }
                            }
                            sql.close();
                            rs.close();
                        } catch (Exception e) {
                            e.printStackTrace();
                        } finally {
                            plugin.closeConnection();
                        }
                    } else if (args[0].equalsIgnoreCase("true")) {
                        plugin.openConnection();
                        try {
                            PreparedStatement sql = plugin.connection.prepareStatement("SELECT subOnly from mc_status");
                            ResultSet rs = sql.executeQuery();
                            if (rs.next()) {
                                if (rs.getInt(1) == 0) {
                                    PreparedStatement sql2 = plugin.connection.prepareStatement("UPDATE mc_status SET subOnly='1'");
                                    sql2.executeUpdate();
                                    sql2.close();
                                    sender.sendMessage("§aA szerver mostantól §csub-only!");
                                } else {
                                    sender.sendMessage("§cA szerver eddig is sub-only volt.");
                                }
                            }
                            sql.close();
                            rs.close();
                        } catch (Exception e) {
                            e.printStackTrace();
                        } finally {
                            plugin.closeConnection();
                        }
                    }
                } else {
                    sender.sendMessage("§bHasználat: /subonly <true/false>");
                }
            }
        }
        return true;
    }
}
