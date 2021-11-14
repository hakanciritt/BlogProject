var blogApp = new Vue({
    el: "#blogApp",
    data() {
        return {
            searchItem: null,
            blogList: blogAll,
            filteredList: []
        }
    },
    methods: {
        searchBlog() {

            if (this.searchItem !== null && this.searchItem !== "" && this.searchItem.length > 1) {
                this.filteredList = this.blogList.filter(x => x.title.toString().toLowerCase().indexOf(this.searchItem.toLowerCase()) !== -1 ||
                    x.categoryName.toString().toLowerCase().indexOf(this.searchItem.toLowerCase()) !== -1);
                this.blogList = this.filteredList;
            } else {
                this.blogList = blogAll;
            }
        },
        blogStatus: function (id) {

            $.ajax({
                type: "POST",
                url: "/Writer/Blog/StatusUpdate",
                data: { blogId: id },
                success: function (result) {
                    if (result.success) {
                        window.location.href = "/yazar/bloglar";

                    } else {
                        console.log(result);
                    }
                }
            });
        }
    }
});