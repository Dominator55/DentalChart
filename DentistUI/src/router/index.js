import { createRouter, createWebHashHistory } from 'vue-router'
import PatientList from '@/views/PatientList'
import DentalChartPage from '@/views/DentalChartPage'
const routes = [
  {
    path: '/',
    name: 'Patients',
    component: PatientList
  },
  {
    path: '/patient/:id/dentalchart',
    name: 'DentalChart',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: DentalChartPage
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
