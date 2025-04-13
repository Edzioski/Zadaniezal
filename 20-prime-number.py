def is_prime(n):
    for i in range(2,n):
        if n % i == 0:
            return False
    return True

try:
    number = int(input("Podaj liczbę: "))
    if is_prime(number):
        print(f"{number} to liczba pierwsza.")
    else:
        print(f"{number} nie jest liczbą pierwszą.")
except:
    print("Niepoprawny format liczby!")
