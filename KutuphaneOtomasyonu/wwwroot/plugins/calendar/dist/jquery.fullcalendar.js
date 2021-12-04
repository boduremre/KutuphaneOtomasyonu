$(document).ready(function () {
    //var date = new Date();
    //var day = date.getDate();
    //var month = date.getMonth();
    //var year = date.getFullYear();

    // anasayfada bulunan takvimi oluþturmak için fullCalendar kullandýk.
    // fullCalendar'ýn çeþitli proplarýný düzenledik.
    $('#calendar').fullCalendar({
        locale: 'tr',
        contentHeight: "auto",
        firstDay: 1,
        fixedWeekCount: false, 
        buttonText: {
            today: 'bugun',
        }, 
        header: {
            //left: 'prev,next today',
            //center: 'title',
            //right: 'month,agendaWeek,agendaDay'
        },
        editable: false,
        droppable: false,
        eventLimit: true,
    });

});