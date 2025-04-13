import random
user_numbers = set()
i = 1
print("Podaj 6 liczb z przedziału od 1 do 49, bez powtórzeń.")
while i <= 6:
    while True:
        try:
            number = int(input(f'Podaj {i} liczbę: '))
            if number not in user_numbers and 0 < number < 50:
                user_numbers.add(number)
                i += 1
                break
            else:
                print("Niepoprawna wartość!")
        except:
            print("Program wczytuje tylko liczby całkowite!")
random_numbers = set(random.sample(range(1,49), 6))
right_numbers = random_numbers.intersection(user_numbers)
print(f'Liczby użytkownika: {user_numbers}')
print(f'Wylosowane liczby: {random_numbers}')
print(f'Trafiłeś {len(right_numbers)} : {right_numbers}')
