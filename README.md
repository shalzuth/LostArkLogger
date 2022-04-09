# Lost Ark Logger
 This project enables you to research and analyze combat actions by parsing packets and using Advanced Combat Tracker (ACT)
 
![Imgur Image](https://i.imgur.com/WrGNiOE.png)
 
# How does this work
 This uses pcap to dump the packets, upload the packets to my server, my server analyzes them and returns a combat log. You can then input that combat log into ACT.
 
# Setup
1. Download the "Lost Ark Logger" packet logger @ https://github.com/shalzuth/LostArkLogger/releases/download/v0.0.0.1/LostArkLogger.exe
2. Download Lost Ark ACT plugin @ https://github.com/shalzuth/LostArkLogger/releases/download/v0.0.0.1/LostArk_ACT_Plugin.dll
3. Download & install ACT @ https://advancedcombattracker.com/download.php
4. Download and install npcap @ https://npcap.com/#download

# ACT Setup
1. Install ACT normally.
2. Add the "Lost Ark ACT Plugin" downloaded earlier on the plugins tab.

# Guide
1. Before entering a dungeon, launch "Lost Ark Logger". Ensure the network interface device is correct as the one that you use for internet access.
2. While in the dungeon, "Lost Ark Logger" will log packets - there's a packet log counter, ensure that it is increasing. The log file will be in the same location as "Lost Ark Logger"
3. After you leave the dungeon, "Lost Ark Logger" uploads the packet dump to the server and downloads the combat log (if the auto-upload box is checked). This combat log will be in the same location as "Lost Ark Logger". If this fails, you can upload the log at http://52.180.146.231/upload
4. In ACT, import the combat log.
5. In ACT, change to the "Main" tab and begin your analysis.

# Known issues
1. Packet logger probably has bugs
2. Server probably doesn't always return a valid combat log. Also very unstable at the moment, it's a work in progress. It probably will go down often in these early stages.
3. ACT plugin is slow (not sure why), timestamps are wrong, and could be more useful. LOOKING FOR HELP TO IMPROVE. The source and sample logs are here, feel free to make it better and pull request.

# Todo
1. Missed skills
2. Healing
3. Shielding
4. Stagger / Destruction
5. Item Usage
6. Revives
8. ???

# WARNING
This is not endorsed by Smilegate or AGS. Usage of this tool isn't defined by Smilegate or AGS. I do not save your data or log it unless you submit a bug report.
 