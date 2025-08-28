Pour passer de Index n (binaire) à Résultat mystery(n) (binaire), on ajoute un '1' à droite d'un '1' de Index n (binaire) pour chacun de ses 1. Si un 1 est déjà présent à droite de de Index n (binaire) on obtient 0.

Exemple : 

Index n (décimal)	Index n (binaire)	Résultat mystery(n) (binaire)	Résultat mystery(n) (décimal)
0	000	000	0
1	001	001	1
2	010	011	3
3	011	010	2
4	100	110	6
5	101	111	7
6	110	101	5
7	111	100	4

Assume n has m bits. Then mystery(n) is the number whose binary representation is the entry in the table T(m) at index position n, where T(m) is defined recursively as follows:

T(1) = [0, 1]

---

Etape 1 : convertir 'n en binaire'
Etape 2 : obtenir 'mystery(n) en binaire'
Etape 3 : convertir 'mystery(n) en binaire en int (résultat final)


---

& (ET au niveau du bit)

| (OU au niveau du bit)

^ (OU exclusif / XOR au niveau du bit)

~ (NON au niveau du bit)

<< (Décalage à gauche)

>> (Décalage à droite)