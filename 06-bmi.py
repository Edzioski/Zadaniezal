weight = float(input("Enter your weight [kg]: "))
height = float(input("Enter your height [m]: "))
bmi = weight / (height ** 2)
print(f"Your bmi is {round(bmi,2)}")
if bmi < 18.5:
    print("You are underweight")
elif 18.5 <= bmi < 25:
    print("You are optimal weight")
else:
    print("You are overweight")
