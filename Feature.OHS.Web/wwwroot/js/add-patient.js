
//post data
$(document).ready(function () {
    // process the form
    $("form.add-patient").on('submit', function (e) {
        e.preventDefault();
        var form = $(this);
        var action = form.attr("action");
        var data = form.serializeArray();
        console.log(data);
        // send ajax
        $.ajax({

            headers: {
                'Accept': 'application/json',
                'content-Type': 'application/json'
            },
            url: 'https://admissions-dot-medipark-hospital.appspot.com/v1/Patient/create',
            crossDomain: true,
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            type: 'POST',
            data: JSON.stringify(getFormData(data)),
            success: function (data) {
                // you can see the result from the console
                // tab of the developer tools
                console.log(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    });
});

//utility function
function getFormData(data) {

    var unindexed_array = data;
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

/*add doctor */


$(document).ready(function () {
    var current_fs, next_fs, previous_fs;
    var left, opacity, scale;
    var animating;

    $(".add-patient").validate({
        errorClass: 'invalid',
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.insertAfter(element.next('span').children());
        },
        highlight: function (element) {
            $(element).next('span').show();
        },
        unhighlight: function (element) {
            $(element).next('span').hide();
        }
    });
    $(".next").click(function () {
        $(".add-patient").validate({
            errorClass: 'invalid',
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.insertAfter(element.next('span').children());
            },
            highlight: function (element) {
                $(element).next('span').show();
            },
            unhighlight: function (element) {
                $(element).next('span').hide();
            }
        });
        if ((!$('.add-patient').valid())) {
            return true;
        }
        if (animating) return false;
        animating = true;
        current_fs = $(this).parent();
        next_fs = $(this).parent().next();
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
        next_fs.show();
        current_fs.animate({
            opacity: 0
        }, {
                step: function (now, mx) {
                    scale = 1 - (1 - now) * 0.2;
                    left = (now * 50) + "%";
                    opacity = 1 - now;
                    current_fs.css({
                        'transform': 'scale(' + scale + ')'
                    });
                    next_fs.css({
                        'left': left,
                        'opacity': opacity
                    });
                },
                duration: 800,
                complete: function () {
                    current_fs.hide();
                    animating = false;
                },
                easing: 'easeInOutExpo'
            });
    });
    $(".submit").click(function () {
        $(".add-patient").validate({
            errorClass: 'invalid',
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.insertAfter(element.next('span').children());
            },
            highlight: function (element) {
                $(element).next('span').show();
            },
            unhighlight: function (element) {
                $(element).next('span').hide();
            }
        });
        if ((!$('.add-patient').valid())) {
            return false;
        }
        if (animating) return false;
        animating = true;
        current_fs = $(this).parent();
        next_fs = $(this).parent().next();
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
        next_fs.show();
        current_fs.animate({
            opacity: 0
        }, {
                step: function (now, mx) {
                    scale = 1 - (1 - now) * 0.2;
                    left = (now * 50) + "%";
                    opacity = 1 - now;
                    current_fs.css({
                        'transform': 'scale(' + scale + ')'
                    });
                    next_fs.css({
                        'left': left,
                        'opacity': opacity
                    });
                },
                duration: 800,
                complete: function () {
                    current_fs.hide();
                    animating = false;
                },
                easing: 'easeInOutExpo'
            });
    });
    $(".previous").click(function () {
        if (animating) return false;
        animating = true;
        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");
        previous_fs.show();
        current_fs.animate({
            opacity: 0
        }, {
                step: function (now, mx) {
                    scale = 0.8 + (1 - now) * 0.2;
                    left = ((1 - now) * 50) + "%";
                    opacity = 1 - now;
                    current_fs.css({
                        'left': left
                    });
                    previous_fs.css({
                        'transform': 'scale(' + scale + ')',
                        'opacity': opacity
                    });
                },
                duration: 800,
                complete: function () {
                    current_fs.hide();
                    animating = false;
                },
                easing: 'easeInOutExpo'
            });
    });
});

$(function () {

    function getAge(born) {
        var now = new Date();

        var birthday = new Date(now.getFullYear(), born.getMonth(), born.getDate());
        if (now >= birthday)
            return now.getFullYear() - born.getFullYear();
        else
            return now.getFullYear() - born.getFullYear() - 1;
    }

    function getCountries() {
        var countries = [
            { "id": 1, "text": "Albania" },
            { "id": 2, "text": "Algeria" },
            { "id": 3, "text": "America" },
            { "id": 4, "text": "Andorra" },
            { "id": 5, "text": "Angola" },
            { "id": 6, "text": "Antigua" },
            { "id": 7, "text": "Argentina" },
            { "id": 8, "text": "Armenia" },
            { "id": 9, "text": "Australia" },
            { "id": 10, "text": "Austria" },
            { "id": 11, "text": "Azerbaijan" },
            { "id": 12, "text": "Bahamas" },
            { "id": 13, "text": "Bahrain" },
            { "id": 14, "text": "Bangladesh" },
            { "id": 15, "text": "Barbados" },
            { "id": 16, "text": "Belarus" },
            { "id": 17, "text": "Belgium" },
            { "id": 18, "text": "Belize" },
            { "id": 19, "text": "Benin" },
            { "id": 20, "text": "Bhutan" },
            { "id": 21, "text": "Bissau" },
            { "id": 22, "text": "Bolivia" },
            { "id": 23, "text": "Bosnia" },
            { "id": 24, "text": "Botswana" },
            { "id": 25, "text": "Brazil" },
            { "id": 26, "text": "British" },
            { "id": 27, "text": "Brunei" },
            { "id": 28, "text": "Bulgaria" },
            { "id": 29, "text": "Burkina" },
            { "id": 30, "text": "Burma" },
            { "id": 31, "text": "Burundi" },
            { "id": 32, "text": "Cambodia" },
            { "id": 33, "text": "Cameroon" },
            { "id": 34, "text": "Canada" },
            { "id": 35, "text": "Cape Verde" },
            { "id": 36, "text": "Central African Republic" },
            { "id": 37, "text": "Chad" },
            { "id": 38, "text": "Chile" },
            { "id": 39, "text": "China" },
            { "id": 40, "text": "Colombia" },
            { "id": 41, "text": "Comoros" },
            { "id": 42, "text": "Congo" },
            { "id": 43, "text": "Costa Rica" },
            { "id": 44, "text": "country debt" },
            { "id": 45, "text": "Croatia" },
            { "id": 46, "text": "Cuba" },
            { "id": 47, "text": "Cyprus" },
            { "id": 48, "text": "Czech" },
            { "id": 49, "text": "Denmark" },
            { "id": 50, "text": "Djibouti" },
            { "id": 51, "text": "Dominica" },
            { "id": 52, "text": "East Timor" },
            { "id": 53, "text": "Ecuador" },
            { "id": 54, "text": "Egypt" },
            { "id": 55, "text": "El Salvador" },
            { "id": 56, "text": "Emirate" },
            { "id": 57, "text": "England" },
            { "id": 58, "text": "Eritrea" },
            { "id": 59, "text": "Estonia" },
            { "id": 60, "text": "Ethiopia" },
            { "id": 61, "text": "Fiji" },
            { "id": 62, "text": "Finland" },
            { "id": 63, "text": "France" },
            { "id": 64, "text": "Gabon" },
            { "id": 65, "text": "Gambia" },
            { "id": 66, "text": "Georgia" },
            { "id": 67, "text": "Germany" },
            { "id": 68, "text": "Ghana" },
            { "id": 69, "text": "Great Britain" },
            { "id": 70, "text": "Greece" },
            { "id": 71, "text": "Grenada" },
            { "id": 72, "text": "Grenadines" },
            { "id": 73, "text": "Guatemala" },
            { "id": 74, "text": "Guinea" },
            { "id": 75, "text": "Guyana" },
            { "id": 76, "text": "Haiti" },
            { "id": 77, "text": "Herzegovina" },
            { "id": 78, "text": "Honduras" },
            { "id": 79, "text": "Hungary" },
            { "id": 80, "text": "Iceland" },
            { "id": 81, "text": "in usa" },
            { "id": 82, "text": "India" },
            { "id": 83, "text": "Indonesia" },
            { "id": 84, "text": "Iran" },
            { "id": 85, "text": "Iraq" },
            { "id": 86, "text": "Ireland" },
            { "id": 87, "text": "Israel" },
            { "id": 88, "text": "Italy" },
            { "id": 89, "text": "Ivory Coast" },
            { "id": 90, "text": "Jamaica" },
            { "id": 91, "text": "Japan" },
            { "id": 92, "text": "Jordan" },
            { "id": 93, "text": "Kazakhstan" },
            { "id": 94, "text": "Kenya" },
            { "id": 95, "text": "Kiribati" },
            { "id": 96, "text": "Korea" },
            { "id": 97, "text": "Kosovo" },
            { "id": 98, "text": "Kuwait" },
            { "id": 99, "text": "Kyrgyzstan" },
            { "id": 100, "text": "Laos" },
            { "id": 101, "text": "Latvia" },
            { "id": 102, "text": "Lebanon" },
            { "id": 103, "text": "Lesotho" },
            { "id": 104, "text": "Liberia" },
            { "id": 105, "text": "Libya" },
            { "id": 106, "text": "Liechtenstein" },
            { "id": 107, "text": "Lithuania" },
            { "id": 108, "text": "Luxembourg" },
            { "id": 109, "text": "Macedonia" },
            { "id": 110, "text": "Madagascar" },
            { "id": 111, "text": "Malawi" },
            { "id": 112, "text": "Malaysia" },
            { "id": 113, "text": "Maldives" },
            { "id": 114, "text": "Mali" },
            { "id": 115, "text": "Malta" },
            { "id": 116, "text": "Marshall" },
            { "id": 117, "text": "Mauritania" },
            { "id": 118, "text": "Mauritius" },
            { "id": 119, "text": "Mexico" },
            { "id": 120, "text": "Micronesia" },
            { "id": 121, "text": "Moldova" },
            { "id": 122, "text": "Monaco" },
            { "id": 123, "text": "Mongolia" },
            { "id": 124, "text": "Montenegro" },
            { "id": 125, "text": "Morocco" },
            { "id": 126, "text": "Mozambique" },
            { "id": 127, "text": "Myanmar" },
            { "id": 128, "text": "Namibia" },
            { "id": 129, "text": "Nauru" },
            { "id": 130, "text": "Nepal" },
            { "id": 131, "text": "Netherlands" },
            { "id": 132, "text": "New Zealand" },
            { "id": 133, "text": "Nicaragua" },
            { "id": 134, "text": "Niger" },
            { "id": 135, "text": "Nigeria" },
            { "id": 136, "text": "Norway" },
            { "id": 137, "text": "Oman" },
            { "id": 138, "text": "Pakistan" },
            { "id": 139, "text": "Palau" },
            { "id": 140, "text": "Panama" },
            { "id": 141, "text": "Papua" },
            { "id": 142, "text": "Paraguay" },
            { "id": 143, "text": "Peru" },
            { "id": 144, "text": "Philippines" },
            { "id": 145, "text": "Poland" },
            { "id": 146, "text": "Portugal" },
            { "id": 147, "text": "Qatar" },
            { "id": 148, "text": "Romania" },
            { "id": 149, "text": "Russia" },
            { "id": 150, "text": "Rwanda" },
            { "id": 151, "text": "Samoa" },
            { "id": 152, "text": "San Marino" },
            { "id": 153, "text": "Sao Tome" },
            { "id": 154, "text": "Saudi Arabia" },
            { "id": 155, "text": "scotland" },
            { "id": 156, "text": "scottish" },
            { "id": 157, "text": "Senegal" },
            { "id": 158, "text": "Serbia" },
            { "id": 159, "text": "Seychelles" },
            { "id": 160, "text": "Sierra Leone" },
            { "id": 161, "text": "Singapore" },
            { "id": 162, "text": "Slovakia" },
            { "id": 163, "text": "Slovenia" },
            { "id": 164, "text": "Solomon" },
            { "id": 165, "text": "Somalia" },
            { "id": 166, "text": "South Africa" },
            { "id": 167, "text": "South Sudan" },
            { "id": 168, "text": "Spain" },
            { "id": 169, "text": "Sri Lanka" },
            { "id": 170, "text": "St. Kitts" },
            { "id": 171, "text": "St. Lucia" },
            { "id": 172, "text": "St Kitts" },
            { "id": 173, "text": "St Lucia" },
            { "id": 174, "text": "Saint Kitts" },
            { "id": 175, "text": "Santa Lucia" },
            { "id": 176, "text": "Sudan" },
            { "id": 177, "text": "Suriname" },
            { "id": 178, "text": "Swaziland" },
            { "id": 179, "text": "Sweden" },
            { "id": 180, "text": "Switzerland" },
            { "id": 181, "text": "Syria" },
            { "id": 182, "text": "Taiwan" },
            { "id": 183, "text": "Tajikistan" },
            { "id": 184, "text": "Tanzania" },
            { "id": 185, "text": "Thailand" },
            { "id": 186, "text": "Tobago" },
            { "id": 187, "text": "Togo" },
            { "id": 188, "text": "Tonga" },
            { "id": 189, "text": "Trinidad" },
            { "id": 190, "text": "Tunisia" },
            { "id": 191, "text": "Turkey" },
            { "id": 192, "text": "Turkmenistan" },
            { "id": 193, "text": "Tuvalu" },
            { "id": 194, "text": "Uganda" },
            { "id": 195, "text": "Ukraine" },
            { "id": 196, "text": "United Kingdom" },
            { "id": 197, "text": "United States" },
            { "id": 198, "text": "Uruguay" },
            { "id": 199, "text": "USA" },
            { "id": 200, "text": "Uzbekistan" },
            { "id": 201, "text": "Vanuatu" },
            { "id": 202, "text": "Vatican" },
            { "id": 203, "text": "Venezuela" },
            { "id": 204, "text": "Vietnam" },
            { "id": 205, "text": "wales" },
            { "id": 206, "text": "welsh" },
            { "id": 207, "text": "Yemen" },
            { "id": 208, "text": "Zambia" },
            { "id": 209, "text": "Zimbabwe" },
            { "id": 210, "text": null }
        ];

        var countriesSelect = $("#country");
		var countriesAccHolder = $("#acc-country");
		var countriesNok = $("#nok-country");
		

        $.each(countries,
            function (i, country) {
                var line = `<option value="${country.id}"> ${country.text} </option>`;

                countriesSelect.append(line);
            });
		
		$.each(countries,
            function (i, country) {
                var line = `<option value="${country.id}"> ${country.text} </option>`;

                countriesAccHolder.append(line);
            });
		
		$.each(countries,
            function (i, country) {
                var line = `<option value="${country.id}"> ${country.text} </option>`;

                countriesNok.append(line);
            });

        //$("#country").select2({
        //    placeholder: 'Select country',
        //    allowClear: true,
        //    maximumSelectionLength: 5
        //});

        return;
    }

    getCountries();

    $("input[name='dateOfBirth']").on('blur', function () {
        var dob = new Date(this.value);

         $("input[name='age']").val( isNaN(getAge(dob)) ? "" : getAge(dob));
    });

    //  Caters for postal address if it's the same as residential

    $("input[name='sameaddress']").click(function () {
        if ($(this).prop("checked") == true) {
            $("input[name='postalBox']").val($("input[name='busAddress']").val()).prop("disabled", true);
            $("input[name='busPostCode']").val($("input[name='resPostCode']").val()).prop("disabled", true);
        }

        getCountries();
    });
});