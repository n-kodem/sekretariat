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

|                               Cel Testu                              |                                                                Błąd                                                                |                                                  Sposób reprodukcji błędu                                                 | Środowisko |                                    Oczekiwany rezultat                                   | Priorytet |   Status   |
|:--------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------------------:|:-------------------------------------------------------------------------------------------------------------------------:|:----------:|:----------------------------------------------------------------------------------------:|:---------:|:----------:|
| Sprawdzenie poprawności systemu<br>wprowadzania danych do aplikacji. |                                       Przy próbie dodania danych<br>pustych program crashuje.                                      |       1.Uruchom aplikacje<br>2. Przejdź do panelu Dodaj<br>3. Wybierz dowolny typ osoby<br>4. Kliknij przycisk Dodaj      | Windows 10 | Wyświetlenie informacji<br>o braku wprowadzonych danych.<br>/<br>Dodanie pustych danych. |   Wysoki  | Rozwiązane |
|     Sprawdzenie poprawności zużywania<br>pamięci przez aplikacje.    | Podczas użytkowania aplikacji poziom zużycia danych <br>rośnie aż w pewnym momencie program staje się niezdatny <br>do użytkowania |                1. Uruchom aplikacje<br>2. Korzystaj z fukcji jakie <br>oferuje aplikacja przez dłuższy czas               | Windows 10 |      Przybliżony do początkowego poziom <br>zużycia pamięci po dłuższym użytkowaniu.     |   Średni  | Rozwiązane |
|         Sprawdzenie poprawności importowania<br>tabel z pliku        |                                   Podczas dodania pliku przypadkowego <br>pliku program crashuje.                                  | 1. Uruchom aplikacje<br>2. Przejdź do panelu ustawień<br>3. Zaimportuj plik niezawierający<br>poprawnych danych do tabeli | Windows 10 |                Informacja o tym, że tabela<br>zawiera nieprawidłowe dane.                |   Wysoki  | Rozwiązane |
|        Sprawdzenie poprawności zmiany<br> skrótów klawiszowych       |                                   Podczas próby zmiany skrótu<br> klawiszowego program crashuje.                                   |  1. Uruchom aplikacje<br>2. Przejdź do panelu ustawień<br>3. Spróbuj wybrać inny skrót w<br> comboboxie do zmiany skrótu  | Windows 10 |                                Zmiana skrótu klawiszowego                                |   Wysoki  | Rozwiązane |

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
       ├── Panel Pracownicy
       ├── Panel Nauczyciele
       ├── Panel Uczniowie
       ├── Panel Selektor
       └── Panel Ustawień

```

Autor: [Nikodem Reszka](https://github.com/n-kodem)
