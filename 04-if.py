# if True:
#     print("True")
# else:
#     print("False")

# check = 0
# if check:
#     print("True")
# else:
#     print("False")

# number1 = 10
# number2 = 10.
# number3 = 2.5
# if number1 == number2:
#     print(f"{number1} == {number2}")
# if number1 is int(number2):
#     print(f"{number1} is int({number2})")
# if number1 is not number3:
#     print(f"{number1} is not {number3}")

number = int(input('Enter a number: '))
print(f"Number {number} is",end=" ")
if number % 2 == 0:
    print('even')
else:
    print("odd")
