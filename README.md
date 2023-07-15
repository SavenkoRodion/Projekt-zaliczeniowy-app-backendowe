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

## Instalacja i konfiguracja
1. Sklonować repositorium
2. Główna solucja to: Project-zaliczeniowy-app-backendowe.sln
3. W Wsei.TeamRatings.Web, Wsei.Matches.Web, Wsei.AuthorizationApi w appsettings.json ustawić poprawny lokalny server ssms (defaultowo jest Server=.\\SQLEXPRESS; )
4. Stworzenie baz

4.1. Odpalić Package Manager Console w Visual Studio.  
Ustawić w niej Default project na Wsei.TeamRatingsApi.Infrastructure.\
Jako Startup Project ustawić Wsei.TeamRatingsApi.Web\
W Package Manager Console odpalić polecenie: Update-Database

4.2. Ustawić w Package Manager Console, Default project na Wsei.Matches.Infrastructure\
Jako Startup Project ustawić Wsei.Matches.Web\
W Package Manager Console odpalić polecenie: Update-Database

4.3. Ustawić w Package Manager Console, Default project na Wsei.AutorizationApi\
Jako Startup Project ustawić Wsei.AutorizationApi\
W Package Manager Console odpalić polecenie: Update-Database

5. Polecamy w Visual studio, nacisnąc prawym przyciskiem myszy na solucje i wybrać opcje Configure Startup Projects.\ 
Wyświetli się okienko gdzie można wybrać parę projektów startowych. Tam polecam ustawić odpalanie tych projektów: Wsei.TeamRatingsApi.Web, Wsei.Matches.Web, Wsei.AutorizationApi

6. W foldrze App znajduje się aplikacja frontendowa. W środku tego folderu trzeba odtwrorzyć cmd i odpalić npm install

## Obsługa systemu

1. Wsei.AutorizationApi

System obsługuje dwie role: User, Admin. Są endpoity z których może korzystać użytkownik niezalogowany

Po przejściu procesu instalacji i konfiguracji systemu opisanego wyżej w bazie będzie stworzony pierwszy administator (username: admin, hasło: admin)

#### Rejestracja
Przy rejestracji jest tworzony użytkownik który będzie miał Role: "User"\
Użytkownikowi role "Admin" może nadać tylko inny użytkownik z rolą "Admin"\
Admin za pomocą endpointa też może zabrać role Admin u innego użytkownika

#### Logowanie
Po poprawnym zalogowaniu endpoint zwraca jwt token.\ 
Po naciśnięciu przycisku Authorize w Swaggerze jego trzeba wpisać w Input w takim formacie: bearer {token}
Wtedy użytkownik będzie zalogowany w swaggerze i mógł korzystać z endpointów

#### W taki sam sposób działa logowanie w Wsei.Matches!

2. Wsei.TeamRatings\
Mikroserwis bez logowania, ma w sobie informacje o wskaźniku oceny zespołu. Jest zrelizowny w onion architecture

3. Wsei.Matches\
Główny mikroserwis. Jest zrelizowny w onion architecture. Większośc endpointów potrzebują być zalogowanym.\
Żeby stowrzyć mecz w bazie, trzeba mieć stworzone w bazie zespoły, ligę, stadium. Żeby stworzyć ligę trzeba mieć stworzone państwo\
W Matches controller, metoda GetById robi dwa strzały do Wsei.TeamRatings.Web do metody GetByTeamName żeby uzyskać wskaźnik oceny zespołu i obliczyć szanse na wygraną zespołu gospodarza.\
Jeżeli w Wsei.TeamRatings.Web nie będzie nazwy chociaż jednego zespołu z pary, szansa na wygraną będzie Null

4. Wsei.Ui
Aplikacja frontendowa napisana w React. Ma zaimplementowany Rounting i Ui za pomocą komponentów React-Bootstrap. Aplikacja wyświetla liste meczy pobieraną z Wsei.Matches. Nie wspiera logowania\
Żeby przetestować aplikacje frontendową trzeba zakomentować autoryzacje endpointów

## Realizacja wymagań

#### Zrealizowane:
Zastosowanie wzorca Onion Architecture w projekcie. 15pkt.\
Kod powinien być hostowany na platformie GitHub + udokumentowany. 10pkt.\
Aplikacja powinna obsługiwać logowanie i rejestracje użytkowników po przez API. 10pkt.\
Aplikacja powinna posiadać połączenie z bazą danych oraz min. 4 encje w tym min. 2 powiązane ze sobą.  10pkt.\
Aplikacja powinna obsługiwać różne role użytkowników - np. user i admin. 5pkt.\
min. 2 mikro-serwisy. 15 pkt.\
mikro-serwisy będą komunikować się między sobą. 14 pkt.\

#### Częściowo zrealizowane
Aplikacja front-endowa (np. w Blazor, AngularJS, etc.) 5 pkt. - Aplikacja jest połączona z mikroserwisem, ma zaimplementowany routing, nie wpiera logowania, nie realizuje wszystkich akcji kontrolerów

#### Niezrealizowane
Testy jednostkowe i integracyjne. 10 pkt.
