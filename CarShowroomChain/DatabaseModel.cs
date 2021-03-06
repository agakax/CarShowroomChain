namespace CarShowroomChain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<car> car { get; set; }
        public virtual DbSet<car_sell> car_sell { get; set; }
        public virtual DbSet<car_shop> car_shop { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<client_order> client_order { get; set; }
        public virtual DbSet<dict_body> dict_body { get; set; }
        public virtual DbSet<dict_color> dict_color { get; set; }
        public virtual DbSet<dict_engine> dict_engine { get; set; }
        public virtual DbSet<dict_fuel> dict_fuel { get; set; }
        public virtual DbSet<dict_gearbox> dict_gearbox { get; set; }
        public virtual DbSet<dict_series> dict_series { get; set; }
        public virtual DbSet<dict_service> dict_service { get; set; }
        public virtual DbSet<model> model { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<user_data> user_data { get; set; }
        public virtual DbSet<full_car> full_car { get; set; }
        public virtual DbSet<client_order_history_car_res> client_order_history_car_res { get; set; }
        public virtual DbSet<client_order_history_car_sell> client_order_history_car_sell { get; set; }
        public virtual DbSet<client_order_history_service> client_order_history_service { get; set; }
        public virtual DbSet<full_reservation> full_reservation { get; set; }
        public virtual DbSet<orders_in_progres> orders_in_progres { get; set; }
        public virtual DbSet<salon_ranking> salon_ranking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>()
                .Property(e => e.cost)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .HasMany(e => e.car_sell)
                .WithRequired(e => e.car)
                .HasForeignKey(e => e.id_car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<car>()
                .HasMany(e => e.reservation)
                .WithRequired(e => e.car)
                .HasForeignKey(e => e.id_car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<car_shop>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<car_shop>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<car_shop>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<car_shop>()
                .Property(e => e.www)
                .IsUnicode(false);

            modelBuilder.Entity<car_shop>()
                .HasMany(e => e.car)
                .WithRequired(e => e.car_shop)
                .HasForeignKey(e => e.id_car_shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<car_shop>()
                .HasMany(e => e.client_order)
                .WithRequired(e => e.car_shop)
                .HasForeignKey(e => e.id_car_shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<car_shop>()
                .HasMany(e => e.user_data)
                .WithRequired(e => e.car_shop)
                .HasForeignKey(e => e.id_car_shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.car_sell)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.id_client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.client_order)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.id_client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.reservation)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.id_client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client_order>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<dict_body>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<dict_body>()
                .HasMany(e => e.car)
                .WithRequired(e => e.dict_body)
                .HasForeignKey(e => e.id_body)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dict_color>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<dict_color>()
                .HasMany(e => e.car)
                .WithRequired(e => e.dict_color)
                .HasForeignKey(e => e.id_color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dict_engine>()
                .Property(e => e.engine)
                .IsUnicode(false);

            modelBuilder.Entity<dict_engine>()
                .HasMany(e => e.car)
                .WithRequired(e => e.dict_engine)
                .HasForeignKey(e => e.id_engine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dict_fuel>()
                .Property(e => e.fuel)
                .IsUnicode(false);

            modelBuilder.Entity<dict_fuel>()
                .HasMany(e => e.car)
                .WithRequired(e => e.dict_fuel)
                .HasForeignKey(e => e.id_fuel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dict_gearbox>()
                .Property(e => e.gearbox)
                .IsUnicode(false);

            modelBuilder.Entity<dict_gearbox>()
                .HasMany(e => e.car)
                .WithRequired(e => e.dict_gearbox)
                .HasForeignKey(e => e.id_gearbox)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dict_series>()
                .Property(e => e.series)
                .IsUnicode(false);

            modelBuilder.Entity<dict_series>()
                .HasMany(e => e.car)
                .WithRequired(e => e.dict_series)
                .HasForeignKey(e => e.id_series)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dict_service>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<dict_service>()
                .Property(e => e.cost)
                .IsUnicode(false);

            modelBuilder.Entity<dict_service>()
                .HasMany(e => e.client_order)
                .WithRequired(e => e.dict_service)
                .HasForeignKey(e => e.id_service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<model>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<model>()
                .HasMany(e => e.car)
                .WithRequired(e => e.model)
                .HasForeignKey(e => e.id_model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user_data>()
                .HasMany(e => e.car_sell)
                .WithRequired(e => e.user_data)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_data>()
                .HasMany(e => e.client_order)
                .WithRequired(e => e.user_data)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_data>()
                .HasMany(e => e.reservation)
                .WithRequired(e => e.user_data)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_data>()
                .HasMany(e => e.role)
                .WithMany(e => e.user_data)
                .Map(m => m.ToTable("user_role").MapLeftKey("id_user").MapRightKey("id_role"));

            modelBuilder.Entity<full_car>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.series)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.engine)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.gearbox)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.fuel)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.cost)
                .IsUnicode(false);

            modelBuilder.Entity<full_car>()
                .Property(e => e.name)
                .IsUnicode(false);

modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.cost)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.car_model)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_res>()
                .Property(e => e.car_color)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.cost)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.car_model)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_car_sell>()
                .Property(e => e.car_color)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.cost)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.service)
                .IsUnicode(false);

            modelBuilder.Entity<client_order_history_service>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<full_reservation>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<full_reservation>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<full_reservation>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<full_reservation>()
                .Property(e => e.series)
                .IsUnicode(false);

            modelBuilder.Entity<full_reservation>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_model)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_color)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_engine)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_gearbox)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_fuel)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_body)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.car_cost)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.shop_address_with_car)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.client_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.client_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.client_address)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.client_phone)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.client_email)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.user_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.user_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.user_phone)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.user_email)
                .IsUnicode(false);

            modelBuilder.Entity<orders_in_progres>()
                .Property(e => e.shop_address_with_seller)
                .IsUnicode(false);

            modelBuilder.Entity<salon_ranking>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<salon_ranking>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<salon_ranking>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<salon_ranking>()
                .Property(e => e.www)
                .IsUnicode(false);
        }
    }
}
