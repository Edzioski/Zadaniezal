str1 = input("Pierwszy wyraz: ")
str2 = input("Drugi wyraz: ")
if sorted(str1) == sorted(str2):
    print("Wyrazy są anagramami")
else:
    print("To nie anagramy!")
