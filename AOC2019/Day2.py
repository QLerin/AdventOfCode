class Day2:
    def part1(self):
        with open(r'C:\Coding\AdventOfCode\AOC2019\Data\Data2.txt') as f:
            strings = f.read().split(',')

        numbers = list(map(int, strings))

        numbers[1] = 12
        numbers[2] = 2

        index = 0
        while True:
            opcode = numbers[index]
            if opcode == 99:
                break

            value = 0
            if opcode == 1:
                value = numbers[numbers[index + 1]] + numbers[numbers[index + 2]]
            if opcode == 2:
                value = numbers[numbers[index + 1]] * numbers[numbers[index + 2]]

            storeIndex = numbers[index + 3]
            numbers[storeIndex] = value

            index += 4

        print("Day 2, part 1: " + str(numbers[0]))

    def part2(self):
        with open(r'C:\Coding\AdventOfCode\AOC2019\Data\Data2.txt') as f:
            strings = f.read().split(',')

        numbers = list(map(int, strings))

        for noun in range(0, 99):
            for verb in range(0, 99):
                output = self.getOutput(noun, numbers.copy(), verb)
                if output == 19690720:
                    print("Day 2, part 2: " + str(100 * noun + verb))
                    return

    def getOutput(self, noun, numbers, verb) -> int:
        numbers[1] = noun
        numbers[2] = verb
        index = 0
        while True:
            opcode = numbers[index]
            if opcode == 99:
                break

            value = 0
            if opcode == 1:
                value = numbers[numbers[index + 1]] + numbers[numbers[index + 2]]
            if opcode == 2:
                value = numbers[numbers[index + 1]] * numbers[numbers[index + 2]]

            storeIndex = numbers[index + 3]
            numbers[storeIndex] = value

            index += 4

        return numbers[0]
