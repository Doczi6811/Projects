package me.doczi;

import org.bukkit.command.CommandExecutor;
import org.bukkit.plugin.java.JavaPlugin;

import java.util.ArrayList;
import java.util.List;

public final class ZsombeyEvent extends JavaPlugin implements CommandExecutor {

    public String eventname = "";

    public int max = 0;
    public boolean eventJoinable = true;
    public List<String> players = new ArrayList<>();
    public List<String> deniedplayers = new ArrayList<>();

    @Override
    public void onEnable() {
        getCommand("event").setExecutor(new Commands(this));
        //getServer().getPluginManager().registerEvents(this, this);
        System.out.println("[ZsombeyEvent] Plugin elindítva!");
    }

    @Override
    public void onDisable() {
        System.out.println("[ZsombeyEvent] Plugin leállítva!");
    }
}
