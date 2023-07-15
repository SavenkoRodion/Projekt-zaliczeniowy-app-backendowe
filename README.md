# Projekt zaliczeniowy L/23 N lab5/2/PROG Programowanie aplikacji back-endowych - Prowadzący: Michał Frontczak

15.07.2023

Autorzy:\
Rodion Savenko\
Adrian Smoła\
Miłosz Smoleń
   
## Opis projektu
### Temat: System dla przeglądu terminów meczy piłkarskich

Projekt składa się z trzech mikroserwisów i projektu ui:
1. Wsei.Matches - główny mikroserwis odpowiedzialny za wyświelanie meczy i ich szczegółów
2. Wsei.Authorization - mikroserwis odpowiedzialny za rejestracje, logowanie i role użytkowników
3. Wsei.TeamRatings - mikroserwis odpowiedzialny za przechowywanie i udostępnianie wskaźniku oceny zespołu. 
Ten wskaźnik jest wykorzystywany przez Wsei.Matches dla obliczania szansy na wygraną zespołu gospodarza.

### Opis technologii i narzędzi użytych w projekcie
Projekt stworzony w Visual Studio 2022\
Mikroserwisy napisane w .NET 7\
Projekt UI napisany w React 18

### Zewnętrzne biblioteki i paczki użyte w projekcie:
Backend:
Automapper

Frontend:
React-botstrap




   

3. Instalacja i konfiguracja
    Instrukcje dotyczące instalacji i konfiguracji projektu

   

4. Realizacja wymagań

Zastosowanie wzorca Onion Architecture w projekcie. 
Kod powinien być hostowany na platformie GitHub + udokumentowany. 
Aplikacja powinna obsługiwać logowanie i rejestracje użytkowników po przez API. 
Aplikacja powinna posiadać połączenie z bazą danych oraz min. 4 encje w tym min. 2 powiązane ze sobą. 
Aplikacja powinna obsługiwać różne role użytkowników - np. user i admin. 

3 mikro-serwisy.
Mikro-serwisy będą komunikować się między sobą. 
Aplikacja front-endowa.
Autoryzacja między mikro serwisami - nieuprawniony mikro-serwis nie powinien uzyskać dostępu.
