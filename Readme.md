# SEKRETARIAT

## Spis treści

- [SEKRETARIAT](#sekretariat)
  - [Spis treści](#spis-treści)
  - [Założenia Projektu](#założenia-projektu)
  - [Wymagane Funkcjonalności](#wymagane-funkcjonalności)
  - [Lista poprawek](#lista-poprawek)
  - [Harmonogram testowania](#harmonogram-testowania)
  - [Baza danych](#baza-danych)
  - [Schemat projektu](#schemat-projektu)

----

## Założenia Projektu

Aplikacja ma umożliwiać wprowadzanie danych uczniów, nauczycieli i pracowników obsługi.

## Wymagane Funkcjonalności

1. [x] Wprowadzanie i modyfikacja danych z formularza
2. [x] Wczytywanie danych z pliku tekstowego (2 wyjątkiem zdjęć)
3. [x] Wczytywanie zdjęć z pliku
4. [x] Wyszukiwanie osób wedlug wszystkich pól
5. [x] Sortowanie wyników
6. [x] Generowanie raportów z wyszukiwania
7. [x] Zapisywanie raportów do pliku tekstowego (bez zdjęć)
8. [x] W pełni funkcjonalne menu, pasek zadań i edytowalne skróty klawiaturowe

## Lista poprawek

- 🕐 v0.0.0 - Added Panels and Basics of DB.

- 🕔 v0.0.1 - Nice gui, "Finished" person add panel.

- 🕖 v0.0.2 - Added sql insert command generator, some bugfixes.

- 🕗 v0.0.3 - added Workers table view and now you can load images.

- 🕘 v0.0.4 - added Workers table view and now you can load images.

- 🕚 v0.0.5 - Now you can edit existing values.
  
- 🕛 v1.0.0 - Now you can change shortcuts, Import/Export tables and user friendly table data selector.

- 🕛 v1.0.1 - Bugfixes, Optimalization and added Readme

## Harmonogram testowania

| Błąd | Status | Data |
|:---:|:---:|:---:|
| Po kliknięciu przycisku dodawania danych program crashuje. | Rozwiązany | 27.12.2021 11:43 |
| Po zmianie wyglądu na ładniejszy program crashuje. | Rozwiązany | 27.12.2021 13:12 |
| Przy próbie dodania pustych danych program crashuje. | Rozwiązany | 27.12.2021 13:46 |
| Podczas opuszczenia okienka wyboru daty bez jej <br>uprzedniego wybrania program crashuje. | Rozwiązany | 27.12.2021 23:36 |
| Podczas szybkiego klikania w przycisk dodawania <br>danych program crashuje. | Rozwiązany | 27.12.2021 23:57 |
| W momencie wejścia do jakiejkolwiek tabeli edycyjnej i zatwierdzenia<br> zmian bez wcześniejszego wprowadzenia takowych program crashuje. | Rozwiązany | 28.12.2021 00:22 |
| W momencie kliknięcia przycisku do przywrócenia zmian <br>sprzed edycji program crashuje. | Rozwiązany | 28.12.2021 01:40 |
| Po dodaniu panelu selektora program crashuje. | Rozwiązany | 28.12.2021 03:34 |
| Po wybraniu dowolnej tabeli, wybraniu kolumny występującej tylko w tej tabeli, <br>a następnie zmiany tabeli można wykonać próbę selekcji z kolumny, która nie istnieje na skutek czego program crashuje. | Rozwiązany | 28.12.2021 04:14 |
| Podczas próby wygenerowania danych z tabeli program crashuje. | Rozwiązany | 28.12.2021 05:54 |
| W momencie kliknięcia przycisku eksportu danych, <br>gdy dane nie są jeszcze wygenerowane program crashuje. | Rozwiązany | 28.12.2021 17:24 |
| Podczas próby eksportu danych program crashuje. | Rozwiązany | 28.12.2021 19:33 |
| Podczas zmiany skrótu klawiszowego program crashuje. | Rozwiązany | 28.12.2021 21:12 |
| Podczas szybkiego kliknięcia w przycisk eksportu danych, <br>gdy okno eksportu danych jest otwarte program crashuje. | Rozwiązany | 28.12.2021 22:37 |
| Podczas próby importowania pliku z wadliwym delimiterem program crashuje. | Rozwiązany | 28.12.2021 23:56 |
| Po próbie importu pliku z niepasującymi danymi program crashuje. | Rozwiązany | 29.12.2021 00:33 |
| Podczas próby importowania pliku bez uprzedniego <br>wybrania tabeli program crashuje. | Rozwiązany | 29.12.2021 01:12 |
| Podczas próby importu z typem importu "nadpisz" program crashuje. | Rozwiązany | 29.12.2021 02:46 |
| Podczas użytkowania aplikacji poziom zużycia danych rośnie <br>aż w pewnym momencie program staje się niezdatny do użytkowania. | Rozwiązany | 29.12.2021 03:32 |
## Baza danych

**W projekcie została wykorzystana baza danych z natępującymi tabelami**

### <p align="center">Uczen</P>

<center>

| imie | druImie | nazwisko | panNazwisko | imRodzicow | zdjecie | plec | pesel |  dataUr  | klasa | grupyJez |
|:----:|:-------:|:--------:|:-----------:|:----------:|:-------:|:----:|:-----:|:--------:|:-----:|:--------:|
| TEXT |   TEXT  |   TEXT   |     TEXT    |    TEXT    |   TEXT  | TEXT |  TEXT | DATETIME |  TEXT |   TEXT   |

</center>

### <p align="center">Pracownik</P>

<center>

| imie | druImie | nazwisko | panNazwisko | imRodzicow | zdjecie | plec | pesel |  dataUr  |  dataZat | opisStan | etat |
|:----:|:-------:|:--------:|:-----------:|:----------:|:-------:|:----:|:-----:|:--------:|:--------:|:--------:|:----:|
| TEXT |   TEXT  |   TEXT   |     TEXT    |    TEXT    |   TEXT  | TEXT |  TEXT | DATETIME | DATETIME |   TEXT   | TEXT |

</center>

### <p align="center">Nauczyciel</P>

<center>

| imie | druImie | nazwisko | panNazwisko | imRodzicow | zdjecie | plec | pesel |  dataUr  |  dataZat | przedmiotyNau | wychowawstwo | klasyZGodz |
|:----:|:-------:|:--------:|:-----------:|:----------:|:-------:|:----:|:-----:|:--------:|:--------:|:-------------:|:------------:|:----------:|
| TEXT |   TEXT  |   TEXT   |     TEXT    |    TEXT    |   TEXT  | TEXT |  TEXT | DATETIME | DATETIME |      TEXT     |     TEXT     |    TEXT    |

</center>

## Schemat projektu

```text
Okno Programu
├── Kafelki operacji na tekstach
│   ├─ Wytnij
│   ├─ Kopiuj
│   └─ Wklej
└── Kafelki przenoszące do paneli
       ├── Panel Dodaj
       │   └─ ComboBox do wybrania typu osoby (Pracownik,Nauczyciel,Uczeń)
       │      ├─ Dowolny wybór 
       │      │   ├─ Pola tekstowe: Imie,Drugie imie, Nazwisko, Nazwisko Panieńskie, Imiona rodziców
       │      │   ├─ Pola specjalne
       │      │   │  ├─ DatePicker: Data Urodzenia
       │      │   │  └─ ComboBox: Płeć 
       │      │   └─ Pole dla zdjęcia: Przycisk do wczytania, Panel do podglądu ścieżki pliku
       │      ├─ Pracownik
       │      │   ├─ Pola tekstowe: Opis Stanowiska, Etat
       │      │   └─ Pola specjalne
       │      │      └─ DatePicker: Data Zatrudnienia
       │      ├─ Nauczyciel
       │      │   ├─ Pola tekstowe: Klasy z Godzinami, Przedmioty Nauczane, Wychowawstwo
       │      │   └─ Pola specjalne
       │      │      └─ DatePicker: Data Zatrudnienia
       │      └─ Uczeń
       │          └─ Pola tekstowe: Klasa, Grupy Językowe
       ├── Panel Pracownicy
       │   ├─ Tabela pracownizy z kolumnami
       │   │  ├─ Imię
       │   │  ├─ Drugie Imię
       │   │  ├─ Nazwisko
       │   │  ├─ Nazwisko Panieńskie
       │   │  ├─ Imiona Rodziców
       │   │  ├─ Płeć
       │   │  ├─ Zdjęcie
       │   │  ├─ Pesel
       │   │  ├─ Data Urodzenia
       │   │  ├─ Data Zatrudnienia
       │   │  ├─ Opis Stanowiska
       │   │  └─ Etat
       │   ├─ Przycisk Zatwierdź Zmiany
       │   └─ Przycisk Odwróć Zmiany
       ├── Panel Nauczyciele
       │   ├─ Tabela Nauczyciele z kolumnami
       │   │  ├─ Imię
       │   │  ├─ Drugie Imię
       │   │  ├─ Nazwisko
       │   │  ├─ Nazwisko Panieńskie
       │   │  ├─ Imiona Rodziców
       │   │  ├─ Płeć
       │   │  ├─ Zdjęcie
       │   │  ├─ Pesel
       │   │  ├─ Data Urodzenia
       │   │  ├─ Data Zatrudnienia
       │   │  ├─ Klasy z Godzinami
       │   │  ├─ Przedmioty Nauczane
       │   │  └─ Wychowawstwo
       │   ├─ Przycisk Zatwierdź Zmiany
       │   └─ Przycisk Odwróć Zmiany
       ├── Panel Uczniowie
       │   ├─ Tabela Uczniowie z kolumnami
       │   │  ├─ Imię
       │   │  ├─ Drugie Imię
       │   │  ├─ Nazwisko
       │   │  ├─ Nazwisko Panieńskie
       │   │  ├─ Imiona Rodziców
       │   │  ├─ Płeć
       │   │  ├─ Zdjęcie
       │   │  ├─ Pesel
       │   │  ├─ Data Urodzenia
       │   │  ├─ Klasa
       │   │  └─ Grupy Językowe
       │   ├─ Przycisk Zatwierdź Zmiany
       │   └─ Przycisk Odwróć Zmiany
       ├── Panel Selektor
       │   ├─ Tabela Generowana na podstawie wyborów użytkownika
       │   ├─ Widok zapytania w SQL
       │   ├─ Pole wyboru tabeli
       │   ├─ Dane do wyboru na podstawie wcześniejszych wyborów użytkownika
       │   │  ├─ Pole wyboru kolumny
       │   │  ├─ Pole wyboru operacji
       │   │  ├─ Pole wyboru kolumny do sortowania
       │   │  ├─ Pole wyboru typu sortowania
       │   │  ├─ Pole wyboru daty
       │   │  └─ Pole wyboru wartości do znalezienia
       │   ├─ Przycisk do generowania raportu na podstawie wyborów użytkownika
       │   └─ Przycisk do eksportowania danych z Tabeli
       └── Panel Ustawień
           ├─ Panel Skrótu 1
           │  ├─ Napis: Skrót 1
           │  ├─ ComboBox z wyborem klawisza specjalnego skrótu
           │  └─ ComboBox z wyborem litery do skrótu
           ├─ Panel Skrótu 2
           │  ├─ Napis: Skrót 2
           │  ├─ ComboBox z wyborem klawisza specjalnego skrótu
           │  └─ ComboBox z wyborem litery do skrótu
           └─ Panel Importu tabel
              ├─ Napis: Import tabel
              ├─ ComboBox z wyborem tabeli do importowania
              ├─ ComboBox z wyborem typu importu (Nadpisz, Dodaj)
              ├─ Combobox z wyborem Delimitera
              └─ Przycisk z wyborem pliku do Importu

```

Autor: [Nikodem Reszka](https://github.com/n-kodem)
