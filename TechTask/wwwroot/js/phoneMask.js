const $input = document.querySelector('[data-js="input"]')
$input.addEventListener('input', handleInput, false)

function handleInput (e) {
    e.target.value = phoneMask(e.target.value)
}

function phoneMask (phone) {
    return phone.replace(/\D/g, '')
        .replace(/^(\d)/, '($1')
        .replace(/^(\(\d{2})(\d)/, '$1) $2')
        .replace(/(\d{4})(\d{1,5})/, '$1-$2')
        .replace(/(-\d{5})\d+?$/, '$1');
}
//
// const $input_fax = document.querySelector('[data-js="input_fax"]')
// $input_fax.addEventListener('input_fax', handleInput, false)
//
// // function handleInput (e) {
// //     e.target.value = faxMask(e.target.value)
// // }
//
// function faxMask (fax) {
//     return fax.replace(/\D/g, '')
//         .replace(/^(\d)/, '($1')
//         .replace(/^(\(\d{2})(\d)/, '$1) $2')
//         .replace(/(\d{4})(\d{1,5})/, '$1-$2')
//         .replace(/(-\d{5})\d+?$/, '$1');
// }