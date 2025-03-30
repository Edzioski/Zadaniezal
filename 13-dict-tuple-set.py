tuple = (20, 30, 40)
print(tuple)
print(tuple[1])
dictionary = {'Pb95': 5.50, 'Pb98': 5.98, 'ON': 5.87, 'LPG':3.15}
for key, value in dictionary.items():
    print(key, value)
setA = {3, 6, 9, 12, 15, 18}
setB = {2, 4, 6, 8, 10, 12, 14, 16}
print(setA.intersection(setB))
print(setA.union(setB))
print(setA.difference(setB))
print(setB.difference(setA))