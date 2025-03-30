n = int(input("Podaj ilość liczb:"))
if n > 0:
    numbers = []
    sum = 0
    for i in range(n):
        x = float(input(f"Podaj {i+1} liczbę: "))
        sum += x
        numbers.append(x)
    numbers.sort()
    print(numbers)
    print(f"Średnia: {sum/n}")
else:
    print("Niepoprawna ilość!")