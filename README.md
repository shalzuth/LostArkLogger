# Lost Ark Logger
 This project enables you to research and analyze combat actions by parsing packets
 
# In-game Overlay
![Imgur Image](https://i.imgur.com/jjXwnOr.gif)

# ACT Plug-in
![Imgur Image](https://i.imgur.com/WrGNiOE.png)
 
# How does this work
 This uses raw sockets to read packets and parses data out of them. This does not interact with the game or any other resources, it is only reading the raw packets received to your PC.
 
# Support
 Please submit an issue on the github repo, or join the discord @ https://discord.gg/MedRDjEwHZ
 
# Setup
1. Download the "Lost Ark Logger" packet logger @ https://github.com/shalzuth/LostArkLogger/releases/latest/download/DpsMeter.exe

# Guide
1. Before entering a dungeon, launch "Lost Ark Logger".
2. While in the dungeon, "Lost Ark Logger" will log packets - there's a packet log counter, ensure that it is increasing. The log file will be in the same location as "Lost Ark Logger". If the overlay shows weird names that are 8 characters long, you didn't open LostArkLogger.exe before a load screen.

# Todo
1. Missed skills
2. Healing
3. Shielding
4. Stagger / Destruction
5. Item Usage
6. Revives
8. ???

# WARNING
This is not endorsed by Smilegate or AGS. Usage of this tool isn't defined by Smilegate or AGS. I do not save your personal identifiable data. Having said that, the .pcap generated can potentially contain sensitive information (specifically, a one-time use token)
  