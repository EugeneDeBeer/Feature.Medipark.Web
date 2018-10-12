
$('body').on('click touch', '.view_data', function(){
    $('#dataModal').modal("show");
});


$('body').on('click touch', '.view_data', function(){ 
        var personId = $(this).attr('id');
        
        $.ajax({
            url: "/systems/assets/php/manage-patient.php",
            method: "post",
            data: {personId:personId },
            success: function(data){
                $('#view-patient').html(data);
                $('#dataModal').modal("show");
            }
        })
});


/*$('.edit_dasta').click ( function(){ 
    
    var personId = $(this).data('id');
   

    $("#patient-data #perID").val( personId );

    $.ajax({
        url: "/systems/assets/php/edit.php",
        method: "post",
        async: true,
       
        data: {personId:personId }, 
        success: function(data){
            $('#insert-form').html(data);
         
        }
    });
    
});*/



 $('body').on('click touch', '.table-action-btn', function(){
        var getId = $(this).attr('data-id');
       
        $('input#userId').val(getId);
        });
 

      //  $('#filePhoto').click();