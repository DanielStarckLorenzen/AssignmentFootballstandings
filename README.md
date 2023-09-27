# AssignmentFootballstandings

## Overview

This solution requires a setup csv file containing league information, a teams file with all teams and 32 fixture files.
This solution is designed to manage and calculate football league standings based on match results provided in CSV files. The project consists of several components:

1. **Data Preparation**: CSV files containing match results are read, and the data is processed to calculate team statistics.

2. **League Split**: The league is split into two groups, Championship Group and Relegation Group, after 22 rounds.

3. **Calculations**: Points, goals scored, goals conceded, and other statistics are calculated for each team based on match results.

4. **Output**: The calculated statistics are presented as a league table, which is printed to the console with a simple and clear overview over the standings, with colors indicating if a team qualified to europe or got relegated.

## Usage

### Data Preparation

1. Place the CSV files containing match results in the `/test/[new folder]` directory. The files should be named "roundX.csv," where X is the round number.

2. Make sure the CSV files have the following format:
  Home Team Abbreviated;Away Team Abbreviated;Score
  FCM;AGF;4-2
  FCN;SIF;1-3
  FCK;LBK;4-3
  RFC;ACH;3-1
  AAB;BIF;0-0
  VFF;OB;4-1

### Reading and Calculating Standings

Rading the setup, teams and rounds happens in the CSVReader class
Calculating happens either within LeagueController or MatchController

### Rule/Error

Error Handling: The code includes basic error handling to catch common issues, such as: 
  - Missing or improperly formatted CSV files
  - Teams playing each other more than twice
  - Team playing itself
Check the console for error messages.
