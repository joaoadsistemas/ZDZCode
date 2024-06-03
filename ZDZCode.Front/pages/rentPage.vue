<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="6">
        <h1>Agendamentos</h1>
        <v-date-picker
          v-model="selectedDate"
          :allowed-dates="disableDatesBeforeToday"
        ></v-date-picker>
      </v-col>
      <v-col cols="12" md="6">
        <v-carousel>
          <v-carousel-item v-for="(hotel, index) in hotels" :key="index">
            <v-card>
              <v-img :src="hotel.imgsUrl[0]" aspect-ratio="2.75"></v-img>
              <div style="margin-left: 70px;">
                <v-card-title>{{ hotel.name }}</v-card-title>
                <v-card-subtitle>{{ hotel.description }}</v-card-subtitle>
                <v-card-actions>
                  <v-btn color="primary" @click="selectHotel(hotel)">
                    Selecionar Hotel
                  </v-btn>
                  <v-btn color="secondary" @click="viewAllBookings(hotel.id)">
                    Ver todos os agendamentos
                  </v-btn>
                </v-card-actions>
              </div>
            </v-card>
          </v-carousel-item>
        </v-carousel>
        <v-btn color="success" @click="openModal" :disabled="!selectedHotel || !selectedDate">
          Agendar
        </v-btn>
      </v-col>
    </v-row>

    <!-- Modal para agendar -->
    <v-dialog v-model="modalOpen" persistent max-width="600">
      <v-card>
        <v-card-title>Agendar</v-card-title>
        <v-card-text>
          <v-form ref="form">
            <v-text-field label="Nome" v-model="formData.name" required></v-text-field>
            <v-text-field label="Sobrenome" v-model="formData.lastName" required></v-text-field>
            <v-text-field label="Telefone" v-model="formData.phone" v-mask="'(##) ####-####'" required></v-text-field>
            <v-text-field label="CPF" v-model="formData.cpf" v-mask="'###.###.###-##'" required></v-text-field>
            <v-text-field label="E-mail" v-model="formData.email" required></v-text-field>
            <v-text-field label="Data de Entrada" v-model="selectedDate" readonly required></v-text-field>
            <v-date-picker label="Data de Saída" v-model="formData.departureDate" :allowed-dates="disableDatesBeforeEntryDate" required></v-date-picker>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="schedule" :disabled="!isValidForm">Agendar</v-btn>
          <v-btn color="secondary" @click="closeModal">Cancelar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!-- Modal para ver todos os agendamentos -->
    <v-dialog v-model="bookingsModalOpen" persistent max-width="600">
      <v-card>
        <v-card-title>Todos os Agendamentos</v-card-title>
        <v-card-text>
          <v-list>
            <v-list-item v-for="(rent, index) in rents" :key="index">
              <v-list-item-content>
                <v-list-item-title>{{ rent.person.name }}</v-list-item-title>
                <v-list-item-subtitle>{{ rent.person.email }}</v-list-item-subtitle>
                <v-list-item-subtitle>{{ formatDate(rent.entryDate) }} - {{ formatDate(rent.departureDate) }}</v-list-item-subtitle>
              </v-list-item-content>
              <v-list-item-action>
                <v-icon @click="openEditModal(rent)">mdi-pencil</v-icon>
                <v-icon @click="deleteBooking(rent.person.id)">mdi-trash-can</v-icon>
              </v-list-item-action>
            </v-list-item>
          </v-list>
        </v-card-text>
        <v-card-actions>
          <v-btn color="secondary" @click="closeBookingsModal">Fechar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!-- Modal para editar -->
    <v-dialog v-model="editModalOpen" persistent max-width="600">
      <v-card>
        <v-card-title>Editar Agendamento</v-card-title>
        <v-card-text>
          <v-form ref="editForm">
            <v-text-field label="Nome" v-model="editFormData.name" required></v-text-field>
            <v-text-field label="Sobrenome" v-model="editFormData.lastName" required></v-text-field>
            <v-text-field label="Telefone" v-model="editFormData.phone" v-mask="'(##) ####-####'" required></v-text-field>
            <v-text-field label="CPF" v-model="editFormData.cpf" v-mask="'###.###.###-##'" required></v-text-field>
            <v-text-field label="E-mail" v-model="editFormData.email" required></v-text-field>
            <v-text-field label="Data de Entrada" v-model="editFormData.entryDate" readonly required></v-text-field>
            <v-date-picker label="Data de Saída" v-model="editFormData.departureDate" :allowed-dates="disableDatesBeforeEntryDate" required></v-date-picker>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" @click="updateBooking" :disabled="!isValidEditForm">Atualizar</v-btn>
          <v-btn color="secondary" @click="closeEditModal">Cancelar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>



<script>
import axios from 'axios';
import { VueMaskDirective } from 'v-mask';
import url from '~/urls';

export default {
  directives: {
    mask: VueMaskDirective,
  },
  computed: {
    isValidForm() {
      return Object.values(this.formData).every(value => value);
    },
    isValidEditForm() {
      return Object.values(this.editFormData).every(value => value);
    },
  },
  data() {
    return {
      selectedDate: '',
      selectedHotel: null,
      hotels: [],
      modalOpen: false,
      bookingsModalOpen: false,
      editModalOpen: false,
      rents: [],
      formData: {
        name: '',
        lastName: '',
        phone: '',
        cpf: '',
        email: '',
        departureDate: null
      },
      editFormData: {
        name: '',
        lastName: '',
        phone: '',
        cpf: '',
        email: '',
        entryDate: '',
        departureDate: ''
      },
      currentRentId: null
    };
  },
  methods: {
  disableDatesBeforeToday(date) {
    const today = new Date();
    return date >= today.toISOString().split('T')[0];
  },
  disableDatesBeforeEntryDate(date) {
    return date > this.selectedDate;
  },
  selectHotel(hotel) {
    this.selectedHotel = hotel;
    console.log('Selected hotel:', hotel);
  },
  async viewAllBookings(hotelId) {
    try {
      const response = await axios.get(`${url.apiUrl}/hotels/${hotelId}`);
      this.selectedHotel = response.data[0];
      console.log('Selected hotel:', this.selectedHotel);
      console.log('Carregando agendamentos...', response);
      this.rents = response.data[0].rents;
      this.bookingsModalOpen = true;
    } catch (error) {
      console.error('Erro ao carregar agendamentos:', error);
    }
  },
  openModal() {
    this.modalOpen = true;
  },
  closeModal() {
    this.modalOpen = false;
  },
  closeBookingsModal() {
    this.bookingsModalOpen = false;
  },
  openEditModal(rent) {
    this.currentRentId = rent.person.id;
    this.editFormData = {
      name: rent.person.name,
      lastName: rent.person.lastName,
      phone: rent.person.phone,
      cpf: rent.person.cpf,
      email: rent.person.email,
      entryDate: new Date(rent.entryDate).toISOString().split('T')[0],
      departureDate: new Date(rent.departureDate).toISOString().split('T')[0]
    };
    this.editModalOpen = true;
  },
  closeEditModal() {
    this.editModalOpen = false;
  },
  async schedule() {
    if (this.selectedDate && this.selectedHotel && Object.values(this.formData).every(value => value)) {
      const entryDate = new Date(this.selectedDate);
      const departureDate = new Date(this.formData.departureDate);

      // Ajuste para garantir que a data seja correta no fuso horário local
      entryDate.setMinutes(entryDate.getMinutes() - entryDate.getTimezoneOffset());
      departureDate.setMinutes(departureDate.getMinutes() - departureDate.getTimezoneOffset());

      const rentData = {
        hotelId: this.selectedHotel.id,
        person: {
          name: this.formData.name,
          lastName: this.formData.lastName,
          phone: this.formData.phone,
          cpf: this.formData.cpf,
          email: this.formData.email
        },
        entryDate: entryDate.toISOString(),
        departureDate: departureDate.toISOString()
      };

      try {
        console.log('Enviando dados para a API...', rentData);
        const response = await axios.post(`${url.apiUrl}/rents`, rentData);
        this.closeModal();
      } catch (error) {
        console.error('Erro ao agendar:', error);
      }
    } else {
      console.error('Preencha todos os campos antes de agendar.');
    }
  },
  async fetchHotels() {
    try {
      const response = await axios.get(`${url.apiUrl}/hotels`);
      this.hotels = response.data;
    } catch (error) {
      console.error('Erro ao carregar hotéis:', error);
    }
  },
  formatDate(date) {
    const options = { year: 'numeric', month: '2-digit', day: '2-digit' };
    return new Date(date).toLocaleDateString('pt-BR', options);
  },
  async updateBooking() {
    if (this.currentRentId && this.selectedHotel && Object.values(this.editFormData).every(value => value)) {
      const entryDate = new Date(this.editFormData.entryDate);
      const departureDate = new Date(this.editFormData.departureDate);
      departureDate.setDate(departureDate.getDate() + 1);

      const rentData = {
        hotelId: this.selectedHotel.id,
        person: {
          name: this.editFormData.name,
          lastName: this.editFormData.lastName,
          phone: this.editFormData.phone,
          cpf: this.editFormData.cpf,
          email: this.editFormData.email
        },
        entryDate: entryDate.toISOString(),
        departureDate: departureDate.toISOString()
      };

      try {
        console.log('Atualizando dados para a API...', rentData);
        await axios.put(`${url.apiUrl}/rents/${this.currentRentId}`, rentData);
        this.closeEditModal();
        this.viewAllBookings(this.selectedHotel.id);
      } catch (error) {
        console.error('Erro ao atualizar agendamento:', error);
      }
    } else {
      console.error('Preencha todos os campos antes de atualizar.');
    }
  },
  async deleteBooking(personId) {
    console.log('Deleting booking for personId:', personId);
    if (!this.selectedHotel) {
      console.error('Nenhum hotel selecionado');
      return;
    }
    try {
      await axios.delete(`${url.apiUrl}/rents/${personId}/${this.selectedHotel.id}`);
      this.rents = this.rents.filter(rent => rent.person.id !== personId);
      console.log(`Deleted booking for personId: ${personId} and hotelId: ${this.selectedHotel.id}`);
    } catch (error) {
      console.error('Erro ao deletar agendamento:', error);
    }
  }
},
mounted() {
  this.fetchHotels();
}
};
</script>



<style scoped>
.v-carousel {
  height: 400px;
}
</style>

