package me.doczi;

import net.luckperms.api.LuckPerms;
import net.luckperms.api.model.user.User;
import net.luckperms.api.node.Node;
import net.luckperms.api.node.NodeType;
import org.bukkit.Bukkit;
import org.bukkit.command.CommandExecutor;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerLoginEvent;
import org.bukkit.plugin.RegisteredServiceProvider;
import org.bukkit.plugin.java.JavaPlugin;

import java.sql.*;
import java.util.UUID;

public final class ZsombeyWhitelist extends JavaPlugin implements Listener, CommandExecutor {

    RegisteredServiceProvider<LuckPerms> provider = null;
    LuckPerms api = null;

    private String url = "jdbc:mysql://eu02-sql.pebblehost.com/customer_648038_whitelist";
    private String user = "customer_648038_whitelist";
    private String password = "s8KxKNb9FSAW@XxFvBnc";
    public Connection connection = null;

    public void openConnection()
    {
        try {
            connection = DriverManager.getConnection(url, user, password);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void closeConnection()
    {
        try{
            connection.close();
        } catch (SQLException e)
        {
            e.printStackTrace();
        }
    }

    public boolean isSubOnly()
    {
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("SELECT subOnly FROM mc_status");
            ResultSet rs = sql.executeQuery();
            if(rs.next())
            {
                if (rs.getInt(1) == 1)
                {
                    sql.close();
                    rs.close();
                    return true;
                }
                else
                {
                    sql.close();
                    rs.close();
                    return false;
                }
            }
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return true;
        } finally {
            closeConnection();
        }
    }

    public boolean isBanned(Player player)
    {
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("SELECT isBanned FROM Adatok WHERE MC_Name=?");
            sql.setString(1,player.getName());
            ResultSet rs = sql.executeQuery();
            if(rs.next())
            {
                if (rs.getInt(1) == 1)
                {
                    sql.close();
                    rs.close();
                    return true;
                }
                else
                {
                    sql.close();
                    rs.close();
                    return false;
                }
            }
            else return false;
        } catch (Exception e){
            e.printStackTrace();
            return false;
        } finally {
            closeConnection();
        }
    }

    public boolean canPlay(Player player)
    {
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("SELECT canPlay FROM Adatok WHERE MC_Name=?");
            sql.setString(1,player.getName());
            ResultSet rs = sql.executeQuery();
            if(rs.next())
            {
                if(rs.getInt(1) == 0)
                {
                    sql.close();
                    rs.close();
                    return false;
                }
                else
                {
                    sql.close();
                    rs.close();
                    return true;
                }
            } else return false;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        } finally {
            closeConnection();
        }
    }

    public boolean playerExists(Player player)
    {
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("SELECT * FROM Adatok WHERE MC_Name=?");
            sql.setString(1,player.getName());
            ResultSet rs = sql.executeQuery();
            if (rs.next())
            {
                sql.close();
                rs.close();
                return true;
            }
            else
            {
                sql.close();
                rs.close();
                return false;
            }
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        } finally {
            closeConnection();
        }
    }

    public boolean hasRank(Player player) {
        UUID uuid = player.getUniqueId();
        User user = api.getUserManager().getUser(uuid);

        String[] ranks = {"donator", "mod", "dev", "owner"};

        for (String rank : ranks)
        {
            if (user.getPrimaryGroup().equals(rank)) return true;
        }
        return false;
    }
    public void setPlayer(Player player)
    {
        boolean gotrank = hasRank(player);
        boolean canPlay = canPlay(player);
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("SELECT uuID, Username FROM mc_adatok WHERE uuID=?");
            UUID uuid = player.getUniqueId();
            sql.setString(1,uuid.toString());
            ResultSet rs = sql.executeQuery();
            if(rs.next()) {
                if(rs.getString(2) != player.getName()) {
                    PreparedStatement sql2 = connection.prepareStatement("UPDATE mc_adatok SET Username=? WHERE uuID=?");
                    sql2.setString(1,player.getName());
                    sql2.setString(2,uuid.toString());
                    sql2.executeUpdate();
                    sql2.close();
                    sql.close();
                    rs.close();
                    User user = api.getUserManager().getUser(uuid);
                    if (canPlay && !gotrank)
                    {
                        Node node1 = Node.builder("group.default").build();
                        user.data().remove(node1);
                        Node node2 = Node.builder("group.sub").build();
                        user.data().add(node2);
                        api.getUserManager().saveUser(user);
                    }
                    else if(!canPlay)
                    {
                        user.data().clear();
                        Node node = Node.builder("group.default").build();
                        user.data().add(node);
                        api.getUserManager().saveUser(user);
                    }
                }
            }
            else
            {
                PreparedStatement sql2 = connection.prepareStatement("INSERT INTO mc_adatok(uuID, Username) VALUES (?,?)");
                sql2.setString(1,uuid.toString());
                sql2.setString(2,player.getName());
                sql2.execute();
                User user = api.getUserManager().getUser(uuid);
                if (canPlay && !gotrank)
                {
                    Node node1 = Node.builder("group.default").build();
                    user.data().remove(node1);
                    Node node2 = Node.builder("group.sub").build();
                    user.data().add(node2);
                    api.getUserManager().saveUser(user);
                }
                else if(!canPlay)
                {
                    user.data().clear();
                    Node node = Node.builder("group.default").build();
                    user.data().add(node);
                    api.getUserManager().saveUser(user);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            closeConnection();
        }
    }

    @EventHandler
    public void onPlayerJoin(PlayerLoginEvent e)
    {
        Player player = e.getPlayer();
        if (!playerExists(player)) { //Van fiókja > Használta DC-n a parancsot
            e.setKickMessage("We haven't found your username in our whitelist. Go to discord and add it with /mcadd command.");
            e.setResult(PlayerLoginEvent.Result.KICK_WHITELIST);
        }
        else if(player.isBanned())
        {
            UUID uuid = player.getUniqueId();
            openConnection();
            try {
                PreparedStatement sql = connection.prepareStatement("SELECT isBanned FROM mc_adatok WHERE uuID=?");
                sql.setString(1,uuid.toString());
                ResultSet rs = sql.executeQuery();
                if(rs.next() && rs.getInt(1) == 0) {
                    PreparedStatement sql2 = connection.prepareStatement("UPDATE mc_adatok SET isBanned=1 WHERE uuID=?");
                    sql2.setString(1,uuid.toString());
                    sql2.executeUpdate();
                    sql2.close();
                    PreparedStatement sql3 = connection.prepareStatement("UPDATE Adatok SET isBanned=1 WHERE MC_Name=?");
                    sql3.setString(1,player.getName());
                    sql2.executeUpdate();
                    sql3.close();
                    sql.close();
                    rs.close();
                }
            } catch (Exception exp)
            {
                exp.printStackTrace();
            } finally {
                closeConnection();
            }
        }
        else if (isBanned(player)) { //Kivan-e bannolva
            e.setKickMessage("You have been banned from the server.");
            e.setResult(PlayerLoginEvent.Result.KICK_WHITELIST);
        }
        else if (!canPlay(player) && isSubOnly()) { //Nincs rangja és subOnly van
            e.setKickMessage("You have no rights to play in this server.");
            e.setResult(PlayerLoginEvent.Result.KICK_WHITELIST);
        }
        else
        {
            setPlayer(player);
        }
    }

    @Override
    public void onEnable()
    {
        getServer().getPluginManager().registerEvents(this, this);
        getCommand("subonly").setExecutor(new Command(this));
        while (api == null && provider == null)
        {
            try {
                Thread.sleep(2000);
                provider = Bukkit.getServicesManager().getRegistration(LuckPerms.class);
                api = provider.getProvider();
                if (api != null)
                {
                    System.out.println("[ZsombeyWhitelist] API megtalálva!");
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        System.out.println("[ZsombeyWhitelist] Plugin elindítva!");
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("UPDATE mc_status SET isRunning='1'");
            sql.executeUpdate();
            sql.close();
            System.out.println("[ZsombeyWhitelist] Az adatbázis frissítve futó szerverként!");
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            closeConnection();
        }
    }

    @Override
    public void onDisable()
    {
        System.out.println("[ZsombeyWhitelist] Plugin leállítva!");
        openConnection();
        try {
            PreparedStatement sql = connection.prepareStatement("UPDATE mc_status SET isRunning='0'");
            sql.executeUpdate();
            sql.close();
            System.out.println("Az adatbázis frissítve stoppolt szerverként!");
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            closeConnection();
        }
    }
}
