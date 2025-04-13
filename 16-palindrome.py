str = input("Wpisz tekst: ")
if str == str[::-1]:
    print(f'Tekst: "{str}" to palindrom.')
else:
    print(f'Tekst: "{str}" nie jest palindromem.')