# Модуль "Searcher"

### 1. [Описание модуля](#module)
### 2. [Используемые технологии и библиотеки](#code)
### 3. [Фронтенд-реализация](#front)
### 4. [Инструкция по запуску](#instruction)
### 5. [Прочее](#credits)
## Module
### В составе общего [проекта](https://github.com/team-5-tutor-project) модуль выполняет следующие функции:

- Отображение списка репетиторов
- Поиск репетиторов по параметрам
- Список избранное
- Черный список
- Страница с подробной информацией про репетитора
- Редактирование расписания репетитора 

### Модуль связан с другими модулями следующим образом:
- С [Аккаунтом](https://github.com/team-5-tutor-project/team-5-account) модуль взаимодействует во время запроса ссылки на чат по имеющемуся ID.
- С [Мессенджером](https://github.com/team-5-tutor-project/team-5-messenger) модуль взаимодействует во время запроса ссылки на чат по имеющемуся ID.

###

## Code

### Backend

- Реализован http-сервер 
- Подключение к базе данных
- Используется [Swagger](http://localhost:6001/swagger/index.html) для тестирования реализуемых методов и взаимодействия с БД


### Frontend

- Используется Blazor
- Всё взаимодейвствие с другими модулями организуется через Redirect

## Front

### Посмотреть реализацию проекта можно по [ссылке](https://github.com/team-5-tutor-project/team-5-searcher/tree/main/Front)

### Страница поиска
![image](https://user-images.githubusercontent.com/79813229/175834647-e8e76ca4-9eb7-486f-806b-c99b3f5e5e80.png)
![image](https://user-images.githubusercontent.com/79813229/175834661-4d227a65-860e-4eb9-b5cb-ef27cd6dc86a.png)

### Выбор параметров на странице поиска
![image](https://user-images.githubusercontent.com/79813229/175834672-e791c63f-3bff-4b34-964c-639867d489bc.png)

### Страница избранное
![image](https://user-images.githubusercontent.com/79813229/175834782-2e441dc2-e1d0-424d-8b85-26710e957f86.png)

### Страница черный список
![image](https://user-images.githubusercontent.com/79813229/175834798-10ef63cc-f44c-486c-8435-ad2bae301ca3.png)

### Страница с подробной информацией о репетиторе 
![image](https://user-images.githubusercontent.com/79813229/175834719-e181171b-b56e-4d48-a869-c47ef17d48af.png)
![image](https://user-images.githubusercontent.com/79813229/175834741-d5ec98ec-816e-440a-ba2c-76ea89dfac3e.png)

### Страница редоктирования расписания репетитора
![image](https://user-images.githubusercontent.com/79813229/175834983-b24b8173-c546-448b-ab00-dbbe0e847819.png)

## Instruction

### Запуск и тестирование

### Шаг 1. Запустите бек (модуль \team-5-searcher\Back). В открывшемся Swagger-интерфейсе можно поработать с данными в БД, но в общем это нужно лишь для активации сервера

### Так выглядит корректно запущенный бек:
![image](https://user-images.githubusercontent.com/79813229/175835150-7293ab22-d21f-4c57-94ed-4dd32ecde3a6.png)
![image](https://user-images.githubusercontent.com/79813229/175835162-c3b7b05e-dea3-4ea8-9a91-f8b12216fb8a.png)
![image](https://user-images.githubusercontent.com/79813229/175835170-f701377d-ea7a-4f3d-b20f-507dc40c0ec5.png)

### Шаг 2. Запустите фронт (модуль \team-5-searcher\Front).

### Шаг 3. Модуль "Поиск" запущен, можно работать. Well done!

## Credits

### Текущий [Список задач](https://github.com/team-5-tutor-project/team-5-searcher/issues)

Team-lead
[Анна Комова](https://github.com/Anny-waay)

[Татьяна Голякова](https://github.com/tatia2501)

[Мария Тетерина](https://github.com/MairianeT)
