form.addEventListener('invalid', function(event){
    event.preventDefault();
}, true);


function validate_business_area_form(){
    //но как передать результат в контроллер
}

function validate_checkboxes(){
    let checkbox = document.querySelectorAll('input[type="checkbox"]');
    let comments = document.getElementById('comments').value
    let marked_checkboxes = [];
    checkbox.forEach((check_box,index) => {
        if(check_box.checked){
            marked_checkboxes.push(check_box);
        }
    });
    return marked_checkboxes.length === 0 && comments == null;
}
