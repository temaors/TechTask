const progress_step_path = document.getElementById('progress_step_path');
const prev = document.getElementById('prev');
const next = document.getElementById('next');
const circles2 = document.querySelectorAll('.circle2');
const steps = document.querySelectorAll('.step');
const keyValueSteps = 'currentActive'

initSteps()

function nextClick(isModelStateValid){
    if (isModelStateValid) {
        let currentActiveStep = getIncrementedCurrentStep()

        if (currentActiveStep > circles2.length) {
            currentActiveStep = circles2.length;
        }
        update(currentActiveStep);
    }
    else{
        let currentActiveStep = getIncrementedCurrentStep()

        if (currentActiveStep > circles2.length) {
            currentActiveStep = circles2.length;
        }
        update(currentActiveStep);
    }
}


function prevClick(){
    let currentActiveStep = getDecrementedCurrentStep()
    if(currentActiveStep < 1) {
        currentActiveStep = 1;
    }
    update(currentActiveStep);
}


next.addEventListener('click', function(){
    let currentActiveStep = getIncrementedCurrentStep()
    if (currentActiveStep > circles2.length) {
        currentActiveStep = circles2.length;
    }
    update(currentActiveStep);
});

prev.addEventListener('click', function(){
    let currentActiveStep = getDecrementedCurrentStep()
    if(currentActiveStep < 1) {
        currentActiveStep = 1;
    }
    update(currentActiveStep);
});


function initSteps(){
    let currentActiveStep
    if (!sessionStorage.getItem(keyValueSteps)){
        currentActiveStep = 1
    }
    else {
        currentActiveStep = sessionStorage.getItem(keyValueSteps)
    }
    update(currentActiveStep)
}

function getIncrementedCurrentStep(){
    let currentActiveStep
    if (!sessionStorage.getItem(keyValueSteps)){
        currentActiveStep = 1
    }
    else {
        currentActiveStep = sessionStorage.getItem(keyValueSteps)
    }
    currentActiveStep++;
    sessionStorage.setItem(keyValueSteps, currentActiveStep)
    return currentActiveStep
}

function getDecrementedCurrentStep(){
    let currentActiveStep
    currentActiveStep = sessionStorage.getItem(keyValueSteps)
    currentActiveStep--;
    sessionStorage.setItem(keyValueSteps, currentActiveStep)
    return currentActiveStep
}

function update(currentActiveStep) {
    circles2.forEach((circle2, idx) => {
        if(idx < currentActiveStep) {
            circle2.classList.add('active');
        } else {
            circle2.classList.remove('active');
        }
    });
    steps.forEach((step, idx) => {
        if(idx < currentActiveStep) {
            step.classList.add('active_step');

        } else {
            step.classList.remove('active_step');
        }
    });
    
    const actives = document.querySelectorAll('.active_step');
    progress_step_path.style.height=`${(actives.length - 1) / (circles2.length - 1) * 100}%`;
    let val = (actives.length - 1) / (circles2.length - 1) * 100;
    if(currentActiveStep === 1) {
        prev.disabled = true;
    } else if (currentActiveStep === circles2.length) {
        next.disabled = true;
    } else {
        prev.disabled = false;
        next.disabled = false;
    }
}
