# Open Hardware Monitor

Monitor computer sensors

## Alerts feature

- Add an alert on any sensor to trigger a sound or executable when a limit has been reached.
- Use "Options" > "Max Alert Rate" to debounce alerts so that they don't repeat too often if the sensor is above the limit continuously. The default is 5 minutes
- You can also play a .wav sound file on the alert by using the "Play sound" option.
- If you want to play an .mp3 file for example you can start VLC with the "Turn on program" action as such:
  - Program: C:\Program Files (x86)\VideoLAN\vlc.exe
  - Argument: file:///c:\temp\alert.mp3 --qt-start-minimized --play-and-exit

