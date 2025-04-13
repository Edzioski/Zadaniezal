# str1 = "Hello World"
# for i in str1:
#     print(i)

str = input('Wpisz tekst: ')
amount = 0
for i in str:
    if i == 'a' or i == 'A':
        amount += 1
print(f'W tekście "{str}" litera a wystepuje {amount} razy.')
