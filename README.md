# TutorProject.Searcher.BLL
## TutorSearcherRepository.cs
### public async Task<List<Tutor>> GetAll():
  возвращает:
  
  список экземпляров класса Tutor (всех из базы данных).
### public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass):

  принимает:
  
  string? Subject – название предмета (может быть null);
  
  WorkFormat? workFormat – формат проведения занятия (из enum класса WorkFormat) (может быть null);
  
  int? minPrice – минимальная цена за занятие (может быть null);
  
  int? maxPrice – максимальная цена за занятие (может быть null);
  
  int? pupilClass – класс обучения (может быть null).
  
  возвращает:
  
  список экземпляров класса TutorToSubject, соответствующих заданным параметрам.

## TutorSearcherService.cs
### public async Task<List<Tutor>> GetAll():
возвращает:
  
список экземпляров класса Tutor (результат работы метода GetAll() в классе TutorSearcherRepository).
### public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass):

  принимает:
  
  string? Subject – название предмета (может быть null);
  
  WorkFormat? workFormat – формат проведения занятия (из enum класса WorkFormat) (может быть null);
  
  int? minPrice – минимальная цена за занятие (может быть null);
  
  int? maxPrice – максимальная цена за занятие (может быть null);
  
  int? pupilClass – класс обучения (может быть null).
  
  возвращает:
  список экземпляров класса TutorToSubject (результат работы метода Search в классе TutorSearcherRepository).

# TutorProject.Searcher.Web
## TutorSearcherController.cs
### public async Task<List<Tutor>> GetAll():
возвращает:
  
список экземпляров класса Tutor (результат работы метода GetAll() в классе TutorSearcherService).
### public async Task<List<TutorToSubject>> Search(string? subject, WorkFormat? workFormat, int? minPrice, int? maxPrice, int? pupilClass):
принимает:
  
string? Subject – название предмета (может быть null);
  
WorkFormat? workFormat – формат проведения занятия (из enum класса WorkFormat) (может быть null);
  
int? minPrice – минимальная цена за занятие (может быть null);
  
int? maxPrice – максимальная цена за занятие (может быть null);
  
int? pupilClass – класс обучения (может быть null).
  
возвращает:
  
список экземпляров класса TutorToSubject (результат работы метода Search в классе TutorSearcherService).
