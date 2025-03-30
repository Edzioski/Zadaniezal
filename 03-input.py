# txt1 = input('Enter a string: ')
# print(txt1)

# number1 = int(input("Enter base: "))
# number2 = int(input("Enter exponent:"))
# print(f"{number1} power {number2} = {number1 ** number2}")

from datetime import datetime

name = input("Your name: ")
birth_year = int(input("Your birth year: "))
current_year = datetime.now().year
age = current_year - birth_year
print(f"Hello {name}, your are {age} years old.")
if age >= 18:
    print("You are adult.")
else:
    print("You are child.")
