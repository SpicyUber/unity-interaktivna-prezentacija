# Unity Interaktivna Prezentacija

> **IMPORTANT:** Due to the nature of the course, the contents of this presentation are in **serbian**.

---

## O projektu

Interaktivna prezentacija koja služi kao uvod u Unity i osnovne komponente unutar Unity-ja.
Ova prezentacija je propratni materijal uz samo predavanje. Cilj je da se studenti **igraju sa prezentacijom tokom predavanja** i time praktično testiraju teorijske koncepte.
Na kraju prezentacije se nalazi **prosta survival igrica** koja služi kao primer primene do tada naučenih koncepata.
Video primer korišćenja prezentacije možete videti [ovde.](https://drive.google.com/file/d/1MKED8tPTpddZ-TxxTsFRPYEmlSUxx7uc/view?usp=sharing)

---

## Šta sam ja uradio

* Odabrao koncepte koji se obrađuju
* Isplanirao i napravio prezentaciju koja se može videti u *Game View*-u
* Implementirao logiku koja čini prezentaciju interaktivnom (Najčešće u *Scene View*-u)  kroz C# skripte. Interaktivni delovi podrazumevaju:

  * Mini igru sa transformom
  * Kalkulator vektora
  * Vizualizaciju World Space vs Local Space
  * Rigidbody mini igru
  * Zombi igru
* Uživo održao predavanje koristeći ovu prezentaciju na predmetu **Simulacija i simulacioni jezici** na **Fakultetu organizacionih nauka**

---

## Kako otvoriti projekat

1. **Klonirajte repozitorijum:**

   ```bash
   git clone https://github.com/SpicyUber/unity-interaktivna-prezentacija.git
   ```

2. **Otvorite Unity Hub**, kliknite na *"Add Project"*, i izaberite folder gde se nalazi projekat.

3. Proverite da li koristite kompatibilnu verziju Unity-ja (preporučena verzija je 2021.3.23f1 ).

---

## Sadržaj

### Uvod

Prost slajd koji služi kao pozadina/ukras prilikom uvoda predavanja. Nije interaktivan.

### Transform

Slajd koji objašnjava tri osnovne osobine `Transform` komponente: **pozicija**, **rotacija**, **skaliranje**.
Sadrži mini igru koja testira razumevanje ovih osobina.

### Vektori

Kalkulator vektora koji omogućava obnavljanje znanja o **vektorima** i **vektorskim operacijama** — ključnim za game dev.

### World vs Local

Objašnjava razliku između **World** i **Local** prostora u Unity-ju.
Omogućava manipulisanje pozicijom i rotacijom objekata, kao i prikaz oba koordinatna sistema.

### Rigidbody

Slajd koji objašnjava osnovne osobine `Rigidbody` komponente.
Sadrži mini igru koja testira razumevanje fizike i interakcije objekata.

### Zombie Game

Primer jednostavne igre u Unity-ju koja kombinuje naučene koncepte i uvodi još neke nove.
Ako ima dovoljno vremena na kraju predavanja, igra se može **implementirati iznova uživo**, što studentima daje uvid u:

* `Start` i `Update` metode
* `Coroutines`
* Prefab-ove
* Instanciranje objekata

