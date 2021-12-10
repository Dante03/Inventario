const URL_API = "https://localhost:44357/api/Juguetes/";
var app = new Vue({
    el: "#app",
    data() {
        return {
            name: '',
            desciption: '',
            Restriction: null,
            company: '',
            price: null,
            listJuguetes: [],
            loading: false,
            loadform: false,
            guardar: false,
            agregar: false
        }
    },
    methods: {
        agregarJuguete() {
            const juguete = {
                id: 0,
                Nombre: this.name,
                Descripcion: this.desciption,
                RestriccionEdad: this.Restriction,
                Compania: this.company,
                Precio: this.price
            }
            //this.loading = true;
            //this.loadform = false;
            //this.agregar = false;
            this.$http.post(URL_API, juguete)
                .then((response) => {

                }).catch((error) => {
                    this.loading = true;
                    this.loadform = false;
                    this.agregar = false;
                    this.obtenerJuguetes();
                    if (error.status == 400) {
                        alert(error.body.Message);
                    }
                });
            this.juguete = '';
            this.name = '';
            this.desciption = '';
            this.Restriction = null;
            this.company = '';
            this.price = null;
            this.listJuguetes = [];
        },

        eliminarJuguete(id) {
            if (confirm("¿Quieres eliminar este elemento?")) {
                this.$http.delete(URL_API + id).then(response => {
                    this.obtenerJuguetes();
                }).catch(error => {
                });
            }
        },
        cargarEdicion(id) {
            this.loading = false;
            this.loadform = true;
            this.guardar = true;
            this.$http.get(URL_API + id).then(response => {
                this.id = response.data.Id,
                    this.name = response.data.Nombre,
                    this.desciption = response.data.Descripcion,
                    this.Restriction = response.data.RestriccionEdad,
                    this.company = response.data.Compania,
                    this.price = response.data.Precio
            }).catch(error => {
            });
        },
        estructuraEdicion(id, name, desciption, Restriction, company, price) {
            const juguete = {
                id: id,
                Nombre: name,
                Descripcion: desciption,
                RestriccionEdad: Restriction,
                Compania: company,
                Precio: price
            }
            this.editarJuguete(id, juguete);
            this.juguete = '';
            this.name = '';
            this.desciption = '';
            this.Restriction = null;
            this.company = '';
            this.price = null;
            this.listJuguetes = [];
            this.loading = true;
            this.guardar = false;
            this.loadform = false;
        },
        editarJuguete(id, juguete) {
            this.loading = false;
            this.$http.put(URL_API + id, juguete).then(response => {
                this.obtenerJuguetes();
            }).catch(error => {

                this.loading = true;
            });
        },
        cambiar() {
            this.loadform = true;
            this.loading = false;
            this.agregar = true;
        },

        obtenerJuguetes() {
            this.loading = true;
            this.guardar = false;
            agregar = false;
            this.$http.get(URL_API).then(function (response) {
                this.listJuguetes = response.data.sort((a, b) => (a.nombre > b.nombre) ? 1 : -1);
            }).catch(error => {
                console.log(error);
            });
        },

    },
    created: function () {
        this.obtenerJuguetes();
    }
})