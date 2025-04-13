first_word = "kowal"
while True:
    user_word = input("Wpisz słowo:")
    if len(user_word) == len(first_word):
        for i in range(len(first_word)):
            if first_word[i] == user_word[i]:
                print(first_word[i], end="")
            else:
                print("_", end="")
        print()
        if first_word == user_word:
            print("Brawo!")
            break
    else:
        print("Niepoprawna długość.")
