<template>
  <section class="section">
    <div class="container">
      <h2 class="title">Filmy</h2>

      <div class="content">
        <div v-for="movie in movies" :key="movie._id">
          <h1>{{ movie.title }}</h1>
          <strong>Gatunek:</strong>
          {{ movie.type }}
          <strong>Date Time:</strong>
          {{ movie.dateTime}}
          <br>
          <button type="button" class="btn btn-info">
            <nuxt-link :to="{name:'movies-id',params: { id:movie._id }}" class="movie">Szczegoły</nuxt-link>
          </button>
          <form method="delete" @submit.prevent="deleteMovie">
            <button
              type="button"
              class="btn btn-danger pull-right"
              data-toggle="modal"
              v-on:submit.prevent="deleteMovie()"
              @click="deleteMovie()"
            >
              <nuxt-link :to="{name:'movies-id',params: { id:movie._id }}" class="movie">Usun film</nuxt-link>
            </button>
          </form>
          <br>
          <br>
          <br>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      movies: []
    };
  },
  mounted() {
    var _this = this;
    axios
      .get("http://localhost:5000/movies")
      .then(function(res) {
        _this.movies = res.data;
        console.log("Data: ", res);
      })
      .catch(function(error) {
        console.log("Error:", error);
      });
  },

  methods: {
    deleteMovie() {
      var _this = this;
      axios
        .delete("http://localhost:5000/movies/" + this.$route.params.id)
        .then(function(res) {
          _this.movies = res.data;
          console.log("Data: ", res);
        })
        .catch(function(error) {
          console.log("Error:", error);
        });
    }
  }
};
</script>


