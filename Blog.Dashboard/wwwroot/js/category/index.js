
var category = new Vue({
    el: '#categoryApp',
    data() {
        return {
            categories: categoriesData,
            searchItem :null,
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
        getCurrentCategory(item) {
            this.updateRequest.status = item.status;
            this.updateRequest.categoryId = item.categoryId;
            this.updateRequest.description = item.description;
            this.updateRequest.name = item.categoryName;
        },
        categorySearch() {
            console.log(this.searchItem);
            if (this.searchItem !== null ) {
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