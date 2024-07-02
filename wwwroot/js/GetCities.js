$(document).ready(function () {
    $('#CountryId').on('change', function () {
        var countryId = $(this).val();
        var cityList = $('#CityId');
        cityList.empty();
        cityList.append('<option></option>');

        if (countryId !== '') {
            $.ajax({
                url: '/Home/GetCities?countryId=' + countryId,
                success: function (cities) {
                    $.each(cities, function (index, city) {
                        $('#CityId').append($('<option></option>').attr('value', city.id).text(city.name));
                    });
                },
                error: function () {
                    alert('errorrr!!');
                },
            });
        }

    })
});