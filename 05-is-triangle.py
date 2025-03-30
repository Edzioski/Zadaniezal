a = int(input('Enter a: '))
b = int(input('Enter b: '))
c = int(input('Enter c: '))
if (a > b and a > c and a < b + c) or (b > a and b > c and b < a + c) or (c > a and c > b and c < a + b) or (a == b and b == c):
    print(f"{a} and {b} and {c} is triangle")
else:
    print(f"{a} and {b} and {c} is not triangle")
