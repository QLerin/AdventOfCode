class Day1:
    def part1(self):
        with open(r'C:\Coding\AdventOfCode\AOC2019\Data\Data1.txt') as f:
            lines = f.read().splitlines()
        fuelSum = 0
        for line in lines:
            fuelSum += int(line) // 3 - 2
        print("Day 1, part 1: " + str(fuelSum))

    def part2(self):
        with open(r'C:\Coding\AdventOfCode\AOC2019\Data\Data1.txt') as f:
            lines = f.read().splitlines()
        fuelSum = 0
        for line in lines:
            fuelSum += self.getNeeded(int(line))
        print("Day 1, part 2: " + str(fuelSum))

    def getNeeded(self, mass) -> int:
        fuel = mass // 3 - 2
        if fuel <= 0:
            return 0
        else:
            return fuel + self.getNeeded(fuel)
