for i in range(int(input("Podaj liczbę: "))):
    print(i, end=" ")
    if i % 3 == 0:
        print("Johnnie", end=" ")
    if i % 5 == 0:
        print("Walker", end=" ")
    print()
