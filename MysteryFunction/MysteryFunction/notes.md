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


---

Pour Mystery(n)
La conversion d'un entier n en son code de Gray équivaut à faire un XOR (^) entre n et n décalé d'un bit vers la droite (n >> 1).

La formule est : gray_code = n ^ (n >> 1)

Regardons avec ton exemple n = 6 (binaire ...110) :

n : ...000110

n >> 1 : ...000011 (on décale tout d'un cran à droite)

XOR :

  ...000110  (n)
^ ...000011  (n >> 1)
----------------
  ...000101  (résultat)
Le résultat ...101 en binaire est 5, ce qui est bien mystery(6).

Ton code, avec sa boucle et ses conditions, arrivait au même résultat de manière procédurale, mais cette formule le fait en une seule opération.