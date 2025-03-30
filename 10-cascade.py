n = int(input('Podaj ilość poziomów: '))
if n > 0:
    for i in range(n):
        print('*'*(i+1))
else:
    print('Niepoprawna wartość!')