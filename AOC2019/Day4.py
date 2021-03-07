class Day4:

    def part1(self):
        min = 356261
        max = 846303
        password = min

        possibleCount = 0

        while password <= max:
            passwordText = str(password)
            isPossible = False
            stringIndex = 0

            while stringIndex < len(str(max)) - 1:
                if passwordText[stringIndex] == passwordText[stringIndex + 1]:
                    isPossible = True
                if passwordText[stringIndex] > passwordText[stringIndex + 1]:
                    isPossible = False
                    break
                stringIndex += 1

            if isPossible:
                possibleCount += 1

            password += 1

        print("Day 4, part 1: " + str(possibleCount))


    def part2(self):
        min = 356261
        max = 846303
        password = min

        possibleCount = 0

        while password <= max:
            passwordText = str(password)
            isPossible = True
            stringIndex = 0

            if not self.doesHaveSameDigits(passwordText):
                password += 1
                continue

            while stringIndex < len(str(max)) - 1:
                if passwordText[stringIndex] > passwordText[stringIndex + 1]:
                    isPossible = False
                    break
                stringIndex += 1

            if isPossible:
                possibleCount += 1

            password += 1

        print("Day 4, part 2: " + str(possibleCount))

    def doesHaveSameDigits(self, passwordText) -> bool:
        usedDigits = []
        index = 0
        while index < len(passwordText) - 1:
            if passwordText[index] == passwordText[index + 1]:
                if not passwordText[index] in usedDigits:
                    if index < len(passwordText) - 2:
                        if passwordText[index] == passwordText[index + 2]:
                            index += 1
                            usedDigits.append(passwordText[index])
                            continue
                        else:
                            return True
                    else:
                        return True
            usedDigits.append(passwordText[index])

            index += 1

        return False
