function calcularedad(fecha){
    const hoy = new Date();
    
    const fechac = new Date(Date.parse(fecha));
    console.log(fechac);
    const edad = hoy.getFullYear() - fechac.getFullYear();
    const mes = hoy.getMonth() - fechac.getMonth();
    
    if(mes < 10 || (mes === 0 && hoy.getDate() < fechac.getDate())){
    }
    return edad;
}




const form = document.querySelector('form');


form.addEventListener('submit', function(e){
    e.preventDefault();

    const matricula = document.getElementById('Matricula').value;
    const nombre = document.getElementById('Nombre').value;
    const apellido = document.getElementById('Apellido').value;
    const fecha = new Date(document.getElementById('FechaDeNacimiento').value);
    const carrera = document.getElementById('Carrera').value;

    const data = {
        matricula: matricula,
        nombre: nombre,
        apellido: apellido,
        FechaDeNacimiento: fecha,
        carrera: carrera
    };


    fetch('https://localhost:7070/Estudiante/agregar',{
        method: 'POST',
        headers : {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(response =>{
        
        return response.json();
    })
    .then(data =>{
        console.log('respuesta de la api', data);
    })
    
});

fetch('https://localhost:7070/Estudiante/obtener')
    .then(response => response.json())
    .then(data => {
        const tbody = document.querySelector('tbody');

        data.forEach(estudiante => {
            
            
            const edad = calcularedad(estudiante.fechaDeNacimiento);
            console.log(edad);
            

            const row = `
                <tr>
                    <td>${estudiante.matricula}</td>
                    <td>${estudiante.nombre}</td>
                    <td>${estudiante.apellido}</td>
                    <td>${edad}</td>
                    <td>${estudiante.carrera}</td>
                    </tr>
                    `;
            tbody.innerHTML += row;
        });
       
    });


   

    