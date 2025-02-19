import { Directive, OnInit, signal, WritableSignal, Type, inject, Injector } from '@angular/core';
import { IGridModel } from '../../models/grid.model';
import { Observable } from 'rxjs';

@Directive()
export abstract class BaseCrudComponent<T> implements OnInit {
    items: WritableSignal<T[]> = signal<T[]>([]);
    selectedItem: T | null = null;
    isModalOpen = signal(false);
    isDeleteModalOpen = signal(false);
    itemId = signal("");
    columns = signal<IGridModel[]>([]);

    abstract modalComponent: Type<any>;  
    private injector = inject(Injector); 
    modalInjector: Injector = this.injector;  

    constructor(private service: any, private gridConfig: IGridModel[]) {
        this.columns.set(gridConfig);
    }

    ngOnInit() {
        this.loadItems();
    }

    loadItems() {
        this.service.getAll().subscribe((data: any) => {
            if (data.success) {
                this.items.set(data.payload);
            } else {
                alert(data.errorMessage);
            }
        });
    }

    openModal(item: T | null = null) {
        this.selectedItem = item;
        this.isModalOpen.set(true); 

        this.modalInjector = Injector.create({
            providers: [
                { provide: 'selectedItem', useValue: this.selectedItem },
                { provide: 'modalClose', useValue: () => this.closeModal() },
                { provide: 'onSave', useValue: (savedItem: T) => this.addOrUpdateItem(savedItem) }
            ],
            parent: this.injector
        });
    }
    

    closeModal() {
        this.isModalOpen.set(false);
    }

    addOrUpdateItem(item: any) {
        const operation: Observable<any> = item.id
            ? this.service.update(item.id, item)
            : this.service.create(item);

        operation.subscribe((response: any) => {
            if (response.success) {
                if (item.id) {
                    this.items.set(this.items().map( (c : any) => (c['id'] === item.id ? response.payload : c)));
                } else {
                    this.items.set([...this.items(), response.payload]);
                }
                this.closeModal();
            } else {
                alert(response.errorMessage);
            }
        });
    }

    confirmDeleteItem(id: string) {
        this.itemId.set(id);
        this.isDeleteModalOpen.set(true);
    }

    deleteItem() {
        if (this.itemId()) {
            this.service.delete(this.itemId()).subscribe((data: any) => {
                if (data.success) {
                    this.items.set(this.items().filter((c : any) => c['id'] !== this.itemId()));
                } else {
                    alert(data.errorMessage);
                }
            });
        }
        this.closeDeleteModal();
    }

    closeDeleteModal() {
        this.isDeleteModalOpen.set(false);
    }
}
