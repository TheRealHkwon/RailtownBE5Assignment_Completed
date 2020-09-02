# RailtownBE5Assignment_Completed
Hyuk's Completed Solution

Notes from Hyuk:

- Although I wanted to implement a better solution, I could not properly figure out how to get an O(n*log(n)) solution. Hence, this solution uses brute force
- Uses a Lat/Long distance calculator taken from https://www.movable-type.co.uk/scripts/latlong.html
- This solution is written as a console app:
   - I wanted to prioritize functionality within the time constraints and chose the easiest way to do so
- User can specify a 5 minute loop or a one-time run of the program
- There is a simple unit test to validate the farthest distance function. Written in Xunit
- Outputs a simple json file to the current directory (Defaults to: ..\repos\RailtownBE5Assignment\RailtownBE5Assignment\RailtownBE5Assignment\bin\Debug\output.json)
- Outputs to console as well
- Total time : 3.5-4 hours


Challenges Encountered:
- Brute force was the easiest way to determine the farthest distance. However, I wasn't certain how to do it in a more elegant way.
- I tried to focus most of my time to find a better algorithm. Unfortunately this was unfruitful
