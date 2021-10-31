var indexApp = new Vue({
    el: "#indexApp",
    data() {
        return {
            searchItem: null,
            filteredBlogList: [],
            blogList: []
        };
    },
    created() {
        this.blogList = blogList;
    },
    methods: {
        searchBlog() {
            console.log(this.filteredBlogList)
            if (this.searchItem !== null && this.searchItem !== "") {
                document.querySelector(".search-result").style.display = "block";
                this.filteredBlogList = this.blogList.filter(x => x.title.toLowerCase().indexOf(this.searchItem.toLowerCase()) !== -1);
                console.log(this.filteredBlogList);
            } else {
                this.filteredBlogList = [];
            }
        }
    }
});