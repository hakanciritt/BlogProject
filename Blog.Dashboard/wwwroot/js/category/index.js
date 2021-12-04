
var category = new Vue({
    el: '#categoryApp',
    data() {
        return {
            categories: categoriesData,
            searchItem: null,
            updateRequest: {
                categoryId: 0,
                description: null,
                name: null,
                status: false
            },
            isError: false,
            validationErrors: []
        }
    },
    methods: {
        getCurrentCategory(categoryId) {
            axios.post('/Category/GetCategory', categoryId, { headers: { 'Content-Type': 'application/json' } })
                .then(res => {
                    if (res.data.success) {

                        this.updateRequest.status = res.data.data.status;
                        this.updateRequest.categoryId = res.data.data.categoryId;
                        this.updateRequest.description = res.data.data.description;
                        this.updateRequest.name = res.data.data.name;
                    }
                }).catch(err => {
                    console.log(err);
                });

        },
        categorySearch() {
            if (this.searchItem !== null) {
                this.categories = categoriesData.filter(x => x.categoryName.toString().toLowerCase().indexOf(this.searchItem.toLowerCase()) !== -1);
            } else {
                this.categories = categoriesData;
            }
        },
        updateCategory(event) {
            event.preventDefault();

            axios.post('/Category/UpdateCategory', this.updateRequest, { headers: { 'Content-Type': 'application/json' } })
                .then(res => {
                    if (res.data.success) {
                        window.location.reload();
                    } else {
                        this.isError = true;
                        this.validationErrors = res.data.data;
                    }
                }).catch(err => {
                    console.log(err);
                });
        }
    }
});