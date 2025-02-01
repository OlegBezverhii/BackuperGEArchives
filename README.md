# BackuperGEArchives

Программа для управлениями архивами GE Proficy Historian (GE Proficy Historian Archive Management Software).
В отличии от [AddGEHistorianArhives](https://github.com/OlegBezverhii/AddGEHistorianArhives), который разработан на базе Historian SDK, в этом проекте используется Proficy Historian ClientAccess API.
Он "нативнее", чем та поделка на COM, но он не может в восстановление архивов нормально.

Для чего вообще эта утилита. Периодически, количество хранящихся архивов увеличивается и нужен инструмент, который:
* по расписанию запускался, подключался к локальному серверу, 
* из DataStore выбирал самый старый архив, remov'ил бы его (делал zip архив и исключал из перечня используемых архивов),
* после создания бэкапа удалял оригинальный .iha архив.

В коде есть наработка ещё по перемещению архива на другой диск, но это на ваше усмотрение. Это не "боевой" вариант программы, но для понимания работы с API подойдет и можно поправить проект под свои нужды - основные действия выделены в отдельные методы, а начальные значения переменных можно в любой момент отредактировать/привязать к элементам интерфейса программы.


### Инструкция в картинках

Для проекта нужна библиотека, она идёт вместе с установкой GE Proficy Historian, но если её у вас нет, то я приложил в папке bin данную библиотеку:

<img src="https://raw.githubusercontent.com/OlegBezverhii/BackuperGEArchives/refs/heads/main/Pictures/1.PNG"/>

В имя сервера стоит локальное имя компьютера, поэтому сразу жмем "Connect". В случае успеха выйдет окно с следующим текстом:

<img src="https://raw.githubusercontent.com/OlegBezverhii/BackuperGEArchives/refs/heads/main/Pictures/2.PNG"/>

Надпись напротив "Имя сервера" изменит на "Подключено" в синем цвете. В "Data Store Name" выбираем нужное нам хранилище.

<img src="https://raw.githubusercontent.com/OlegBezverhii/BackuperGEArchives/refs/heads/main/Pictures/3.PNG"/>

После выбранного нами хранилища нажимаем кнопку "Запросить". В таблице появится информация по архивам, а в логе программы появится необходимая информация.

<img src="https://raw.githubusercontent.com/OlegBezverhii/BackuperGEArchives/refs/heads/main/Pictures/4.PNG"/>

Дожидаетесь исполнения, после чего можно проверить в папке с архивами появившийся файл zip архива, а в Historian Administration что нужный вам архив в хранилище исключен.

Для отключения от сервера необходимо нажать кнопку "Disconnect".

После отключения очищается список архивов, лог работы программы, а надпись меняется на "Отключено" и изменяет цвет на красный:

<img src="https://raw.githubusercontent.com/OlegBezverhii/BackuperGEArchives/refs/heads/main/Pictures/5.PNG"/>


Если вам нужно массово добавить много архивов (которые случайно слетели в конфигурации), то обратитесь уже к этому проекту - [AddGEHistorianArhives](https://github.com/OlegBezverhii/AddGEHistorianArhives).