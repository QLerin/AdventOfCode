class Day3:

    def part1(self):
        with open(r'C:\Coding\AdventOfCode\AOC2019\Data\Data3.txt') as f:
            lines = f.read().splitlines()
        firstPath = lines[0].split(',')
        secondPath = lines[1].split(',')

        firstPathCoordinates = self.wiresPositionsDictionary(firstPath)
        secondPathCoordinates = self.wiresPositionsDictionary(secondPath)

        manhattanDistance = 9999999999999
        for coordinate in firstPathCoordinates:
            if coordinate in secondPathCoordinates:
                distance = abs(coordinate.X) + abs(coordinate.Y)
                if 0 < distance < manhattanDistance:
                    manhattanDistance = distance

        print("Day 3, part 1: " + str(manhattanDistance))

    def wiresPositionsDictionary(self, commands) -> dict:

        position = Position(0, 0)
        dictionary = {position: 0}

        for command in commands:
            firstLetter = command[0]
            number = int(command[1:])
            i = 0
            while i < number:
                i += 1
                if firstLetter == 'U':
                    position = Position(position.X, position.Y + 1)
                    if position.X != 0 and position.Y != 0:
                        dictionary[position] = 1
                if firstLetter == 'D':
                    position = Position(position.X, position.Y - 1)
                    if position.X != 0 and position.Y != 0:
                        dictionary[position] = 1
                if firstLetter == 'L':
                    position = Position(position.X - 1, position.Y)
                    if position.X != 0 and position.Y != 0:
                        dictionary[position] = 1
                if firstLetter == 'R':
                    position = Position(position.X + 1, position.Y)
                    if position.X != 0 or position.Y != 0:
                        dictionary[position] = 1

        return dictionary

    def part2(self):
        with open(r'C:\Coding\AdventOfCode\AOC2019\Data\Data3.txt') as f:
            lines = f.read().splitlines()
        firstPath = lines[0].split(',')
        secondPath = lines[1].split(',')

        firstPathCoordinates = self.wiresPositionsDictionaryWithTime(firstPath)
        secondPathCoordinates = self.wiresPositionsDictionaryWithTime(secondPath)

        minimumTime = 9999999999999
        for coordinate in firstPathCoordinates:
            if coordinate in secondPathCoordinates:
                time = firstPathCoordinates[coordinate] + secondPathCoordinates[coordinate]
                if 0 < time < minimumTime:
                    minimumTime = time

        print("Day 3, part 2: " + str(minimumTime))

    def wiresPositionsDictionaryWithTime(self, commands) -> dict:

        position = Position(0, 0)
        dictionary = {position: 0}
        time = 1

        for command in commands:
            firstLetter = command[0]
            number = int(command[1:])

            i = 0
            while i < number:
                i += 1
                if firstLetter == 'U':
                    position = Position(position.X, position.Y + 1)
                    self.addToDictionary(dictionary, position, time)
                if firstLetter == 'D':
                    position = Position(position.X, position.Y - 1)
                    self.addToDictionary(dictionary, position, time)
                if firstLetter == 'L':
                    position = Position(position.X - 1, position.Y)
                    self.addToDictionary(dictionary, position, time)
                if firstLetter == 'R':
                    position = Position(position.X + 1, position.Y)
                    self.addToDictionary(dictionary, position, time)
                time += 1

        return dictionary

    def addToDictionary(self, dictionary, position, time):
        if (position.X != 0 or position.Y != 0) and position not in dictionary:
            dictionary[position] = time


class Position:
    X = 0
    Y = 0

    def __init__(self, x, y):
        self.X = x
        self.Y = y

    def __eq__(self, other):
        return self.X == other.X and self.Y == other.Y

    def __hash__(self):
        return hash((self.X, self.Y))
