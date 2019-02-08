<template>
  <nav class="navbar is-light">
    <div class="container">
      <div class="navbar-brand">
        <nuxt-link class="navbar-item" to="/">CinemaX</nuxt-link>

        <button class="button navbar-burger">
          <span></span>
          <span></span>
          <span></span>
        </button>
      </div>

      <div class="navbar-menu">
        <div class="navbar-end">
          <div class="navbar-item has-dropdown is-hoverable" v-if="isAuthenticated">
            <a class="navbar-link">
              {{ loggedInUser.username }}
            </a>
            <div class="navbar-dropdown">
              <nuxt-link class="navbar-item" to="/profile">Profil uzytkownika</nuxt-link>
              <hr class="navbar-divider">
              <a class="navbar-item" @click="logout">Wyloguj sie</a>
            </div>
          </div>
          <template v-else>
            <nuxt-link class="navbar-item" to="/movies">Filmy</nuxt-link>
            <nuxt-link class="navbar-item" to="/register">Rejestracja</nuxt-link>
            <nuxt-link class="navbar-item" to="/login">Logowanie</nuxt-link>
          </template>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['isAuthenticated', 'loggedInUser']),
  },

  methods: {
    async logout() {
      await this.$auth.logout();
    },
  },
};
</script>

